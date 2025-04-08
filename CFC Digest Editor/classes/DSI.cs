using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFC_Digest_Editor.classes
{
    public class DSI
    {
        const int FolderSize = 0x40000;
        const int HeaderSize = 0x40;

        public static void ExtractAndMerge(string inputPath, string outputVideoPath, string outputAudioPath)
        {
             var stream = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
             var videoOutput = new FileStream(outputVideoPath, FileMode.Create, FileAccess.Write);
             var audioOutput = new FileStream(outputAudioPath, FileMode.Create, FileAccess.Write);

            int folderIndex = 0;

            while (stream.Position + FolderSize <= stream.Length)
            {
                byte[] folderData = new byte[FolderSize];
                stream.Read(folderData, 0, FolderSize);

                 var ms = new MemoryStream(folderData);
                 var br = new BinaryReader(ms);

                int streamCount = br.ReadInt32();
                int m2vStartOffset = br.ReadInt32();
                br.ReadInt32(); // Desconhecido
                int m2vSize = br.ReadInt32();
                int vagStartOffset = br.ReadInt32();
                br.ReadInt32(); // Desconhecido
                int vagSize = br.ReadInt32();

                // Adiciona M2V ao arquivo final
                if (m2vSize > 0 && m2vStartOffset + m2vSize <= FolderSize)
                {
                    ms.Position = m2vStartOffset;
                    byte[] m2vData = br.ReadBytes(m2vSize);
                    videoOutput.Write(m2vData, 0, m2vData.Length);
                }

                // Adiciona VAG ao arquivo final
                if (vagSize > 0 && vagStartOffset + vagSize <= FolderSize)
                {
                    ms.Position = vagStartOffset;
                    byte[] vagData = br.ReadBytes(vagSize);
                    audioOutput.Write(vagData, 0, vagData.Length);
                }

                folderIndex++;
            }

            MessageBox.Show("Extracted sucessfully!", "Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static void RebuildFromOriginal(
        string originalDsiPath,
        string newM2vPath,
        string newVagPath,
        string outputDsiPath)
        {
            byte[] m2vData = File.ReadAllBytes(newM2vPath);
            byte[] vagData = File.ReadAllBytes(newVagPath);

             var originalStream = new FileStream(originalDsiPath, FileMode.Open, FileAccess.Read);
             var outputStream = new FileStream(outputDsiPath, FileMode.Create, FileAccess.Write);

            int m2vOffset = 0;
            int vagOffset = 0;
            int folderIndex = 0;
            const int FolderSize = 0x40000;

            while (originalStream.Position + FolderSize <= originalStream.Length)
            {
                byte[] folderData = new byte[FolderSize];
                originalStream.Read(folderData, 0, FolderSize);

                 var ms = new MemoryStream(folderData);
                 var br = new BinaryReader(ms);
                 var newFolder = new MemoryStream();
                 var bw = new BinaryWriter(newFolder);

                // Lê o header
                int streamCount = br.ReadInt32();   // 0x00
                int m2vStart = br.ReadInt32();      // 0x04
                int unknown1 = br.ReadInt32();      // 0x08
                int m2vSize = br.ReadInt32();       // 0x0C
                int vagStart = br.ReadInt32();      // 0x10
                int unknown2 = br.ReadInt32();      // 0x14
                int vagSize = br.ReadInt32();       // 0x18

                // Copia o header original inteiro
                newFolder.Write(folderData, 0, m2vStart);

                // ========================
                // ✅ Substitui M2V
                // ========================
                int availableM2v = Math.Min(m2vSize, m2vData.Length - m2vOffset);
                if (availableM2v > m2vSize)
                {
                    throw new Exception($"Novo bloco M2V é maior do que o permitido na pasta {folderIndex}.");
                }

                newFolder.Position = m2vStart;
                bw.Write(m2vData, m2vOffset, availableM2v);
                m2vOffset += availableM2v;

                // Preenche com zeros se sobrar espaço
                int padM2v = m2vSize - availableM2v;
                if (padM2v > 0)
                    bw.Write(new byte[padM2v]);

                // ========================
                // ✅ Substitui VAG
                // ========================
                int availableVag = Math.Min(vagSize, vagData.Length - vagOffset);
                if (availableVag > vagSize)
                {
                    throw new Exception($"Novo bloco VAG é maior do que o permitido na pasta {folderIndex}.");
                }

                newFolder.Position = vagStart;
                bw.Write(vagData, vagOffset, availableVag);
                vagOffset += availableVag;

                // Preenche com zeros se sobrar espaço
                int padVag = vagSize - availableVag;
                if (padVag > 0)
                    bw.Write(new byte[padVag]);

                // ========================
                // ✅ Copia resto dos dados da pasta original (caso não sejam do áudio/vídeo)
                // ========================
                if (newFolder.Length < FolderSize)
                {
                    newFolder.Write(folderData, (int)newFolder.Length, FolderSize - (int)newFolder.Length);
                }

                // Grava no arquivo final
                newFolder.Position = 0;
                newFolder.CopyTo(outputStream);

                folderIndex++;
            }

            MessageBox.Show("Rebuild completed successfully!", "Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
