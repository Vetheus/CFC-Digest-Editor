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


    }
}
