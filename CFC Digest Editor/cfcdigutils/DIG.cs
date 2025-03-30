using CFC_Digest_Editor.Classes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace CFC_Digest_Editor.CFCDIGUtils
{
    public static class DIG
    {
        public static int PakCount;

        public static void Unpack(BinaryReader dig, BinaryReader fat, string outputPath, List<Package> PakArchiveList, List<Records> RecordsList)
        {
            string originalText = Main.maininstance.Text;
            int extractedFiles = 0;
            List<string> paddingContents = new List<string>();
            int packageIndex = 0;

            if (Directory.Exists(outputPath))
                Directory.Delete(outputPath, true);

            foreach (Records record in RecordsList)
            {
                Package package = PakArchiveList[packageIndex];
                Main.maininstance.Text = $"{originalText} - Reading files from Packages ({packageIndex + 1}/{PakCount})...";
                packageIndex++;

                dig.BaseStream.Position = package.Offset;
                byte[] packageData = package.IsCompressed
                    ? Compression.Decompress(dig.ReadBytes(package.cSize), package.Size)
                    : dig.ReadBytes(package.Size);

                if (package.SecCount != record.SecCount)
                {
                    MessageBox.Show("CFC.DIG and FAT not matching!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Main.error = true;
                    Main.maininstance.Text = originalText;
                    return;
                }

                ExtractFilesFromPackage(fat, record, package, packageData, outputPath, ref extractedFiles, paddingContents);
            }

            if (paddingContents.Count > 0)
                File.WriteAllLines(Path.Combine(outputPath, "paddEntries.txt"), paddingContents);

            Main.maininstance.Text = originalText;
        }

        private static void ExtractFilesFromPackage(BinaryReader fat, Records record, Package package, byte[] packageData, string outputPath, ref int extractedFiles, List<string> paddingContents)
        {
            for (int sectionIndex = 0; sectionIndex < package.SecCount; sectionIndex++)
            {
                fat.BaseStream.Position = record.Offset + 12 * sectionIndex;
                int entryOffset = fat.ReadInt32();
                int fileCount = fat.ReadInt32();
                int paddedSize = fileCount == 0 ? 0 : BinaryUtils.GetPaddedSize(4 + 8 * fileCount, 16);

                if (fileCount == 0)
                {
                    ExtractSingleFile(fat, packageData, entryOffset, sectionIndex, outputPath, ref extractedFiles);
                }
                else
                {
                    ExtractMultipleFiles(fat, packageData, entryOffset, fileCount, sectionIndex, paddedSize, outputPath, ref extractedFiles, paddingContents);
                }
            }
        }

        private static void ExtractSingleFile(BinaryReader fat, byte[] packageData, int entryOffset, int sectionIndex, string outputPath, ref int extractedFiles)
        {
            fat.BaseStream.Position = entryOffset + 1;
            int fileSize = BitConverter.ToInt32(packageData, 4 + 16 * sectionIndex);
            int fileOffset = BitConverter.ToInt32(packageData, 8 + 16 * sectionIndex);
            byte[] fileData = new byte[fileSize];
            Array.Copy(packageData, fileOffset, fileData, 0, fileSize);

            string filename = StringTerminator.ReadCFCFilename(fat);
            string filePath = Path.Combine(outputPath, "data", filename);
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllBytes(filePath, fileData);

            extractedFiles++;
        }

        private static void ExtractMultipleFiles(BinaryReader fat, byte[] packageData, int entryOffset, int fileCount, int sectionIndex, int paddedSize, string outputPath, ref int extractedFiles, List<string> paddingContents)
        {
            //Theus code was inverted those two causing files wrong sizes
            int totalSize = BitConverter.ToInt32(packageData, 4 + 16 * sectionIndex);
            int baseOffset = BitConverter.ToInt32(packageData, 8 + 16 * sectionIndex);

            if (BitConverter.ToInt32(packageData, baseOffset) != fileCount)
            {
                MessageBox.Show("CFC.DIG and FAT not matching!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Main.error = true;
                return;
            }

            for (int fileIndex = 0; fileIndex < fileCount; fileIndex++)
            {
                fat.BaseStream.Position = entryOffset + 8 * fileIndex;
                int nameOffset = fat.ReadInt32();

                if (nameOffset != 0)
                {
                    fat.BaseStream.Position = nameOffset + 1;
                    string filename = StringTerminator.ReadCFCFilename(fat);
                    string filePath = Path.Combine(outputPath, "data", filename);
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));

                    int fileSize = BitConverter.ToInt32(packageData, baseOffset + 8 + 8 * fileIndex);

                    int fileDataOffset = BitConverter.ToInt32(packageData, baseOffset + 4 + 8 * fileIndex);

                    if (fileSize > 0)
                    {
                        byte[] fileData = new byte[fileSize];
                        Array.Copy(packageData, baseOffset + fileDataOffset, fileData, 0, fileSize);
                        File.WriteAllBytes(filePath, fileData);
                        extractedFiles++;
                        paddedSize += BinaryUtils.GetPaddedSize(fileSize, 16);
                    }
                    else
                    {
                        File.Create(filePath).Close();
                        extractedFiles++;
                    }
                }
            }
        }

        public static void Pack(BinaryReader fat, BinaryWriter dig, List<Records> RecordsList, string dataFolder)
        {
            string originalText = Main.maininstance.Text;
            int currentFileIndex = 0;
            List<string> paddingEntries = new List<string>();

            string paddingFilePath = Path.Combine(Path.GetDirectoryName(dataFolder), "paddEntries.txt");
            if (File.Exists(paddingFilePath))
                paddingEntries = File.ReadAllLines(paddingFilePath).ToList();

            dig.Write(new byte[BinaryUtils.GetPaddedSize(PakCount * 16 + 16, 2048, 16)]);
            int dataOffset = 0;

            foreach (Records record in RecordsList)
            {
                Main.maininstance.Text = $"{originalText} - Writing Packages ({dataOffset + 1}/{PakCount})...";
                dataOffset++;
                // Implementação do processo de empacotamento
            }

            dig.BaseStream.Seek(0, SeekOrigin.End);
            dig.WritePadding(2048);
            Main.maininstance.Text = originalText;
        }
    }
}
