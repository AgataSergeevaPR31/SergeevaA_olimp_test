//������ �� ���������
using FamiliaI_PR_31_zd_1;
using FamiliaI_PR_31_zd_4;
using FamiliaI_PR_31_zd_6;

//���� �������� ��� 2 ��, �� ������� ���������������� ����� � ����� � �������� 6

namespace Sergeeva_olimp_test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //��� 1 �������
        string expectedNamespace1 = ""; //������ �� ���������
        string inputPath1 = @"\input.txt"; //������ �� ������ ����
        string outputPath1 = @"\output.txt"; //������ �� ������ ����

        //��� 4 �������
        string expectedNamespace2 = ""; //������ �� ���������
        string inputPath2 = @"\input.txt"; //������ �� ������ ����
        string outputPath2 = @"\output.txt"; //������ �� ������ ����


        //��� 6 �������
        string expectedNamespace6 = ""; //������ �� ���������
        string inputPath6 = @"\input.txt"; //������ �� ������ ����
        string outputPath6 = @"\output.txt"; //������ �� ������ ����



        //
        //HELP METHODS
        //

        //�����-�������� �� �������� ������������ ���� ������� ������ � ����� � �������� �������
        private bool ValidateInputFromFile1(string filePath)
        {
            // ������ ���������� �����
            var input = File.ReadAllText(filePath).Trim();

            // ���������, ��� ������ �� ������
            if (string.IsNullOrEmpty(input)) return false;

            // ��������� ������ �� ��������
            var parts = input.Split(' ');

            // ���������, ��� ����� ��� ��������
            if (parts.Length != 2) return false;

            // ���������, ��� ��� �������� - ����� �����
            return int.TryParse(parts[0], out _) && int.TryParse(parts[1], out _);
        }

        //�����-�������� �� �������� ������������ ���� ���������� � ����� � �����������
        private bool IsOutputFileValid1(string filePath)
        {
            // ������ ���������� �����
            var input = File.ReadAllText(filePath).Trim();

            // ���������, ��� ������ ������
            if (string.IsNullOrEmpty(input)) return true; // ������ ���� ��������� ��������

            // ��������� ������ �� ��������
            var parts = input.Split(' ');

            // ���������, ��� ����� ���� �������
            if (parts.Length != 1) return false;

            // ���������, ��� ������� - ����� �����
            return int.TryParse(parts[0], out _);
        }
        //�����-�������� ��� �������� � ���������� ��������� �����
        public string Helper(string inputValue)
        {
            // �������� ��������� ������
            string inputFile = Path.GetTempFileName();
            string outputFile = Path.GetTempFileName();
            try
            {
                // ���������� ������� ������
                File.WriteAllText(inputFile, inputValue);
                // ������ ���������
                Program.Main(new string[] { inputFile, outputFile });
                // ������ ����������
                return File.ReadAllText(outputFile).Trim();
            }
            finally
            {
                // �������� ��������� ������
                if (File.Exists(inputFile)) File.Delete(inputFile);
                if (File.Exists(outputFile)) File.Delete(outputFile);
            }
        }

        //������� 1
        //


        //���������� �������� NAMESPACE
        [Test]
        public void A1_Namespace()
        {
            string actualNamespace = typeof(Program).Namespace;

            Assert.AreEqual(expectedNamespace1, actualNamespace);
        }

        //������� ����� � �������� �������
        [Test]
        public void B1_InputFileExists()
        {
            Assert.IsTrue(File.Exists(inputPath1), $"���� {inputPath1} �� ������.");
        }

        //������� ����� ��� ������ ����������
        [Test]
        public void C1_OutputFileExists()
        {

            // ��������� ������� ������
            Assert.IsTrue(File.Exists(outputPath1), $"���� {outputPath1} �� ������.");
        }

        //������������ ������� ������
        [Test]
        public void D1_InputFileDate()
        {
            Assert.IsTrue(ValidateInputFromFile1(inputPath1));
        }

        //������������� ���� ����������
        [Test]
        public void E1_OutputFileValidation()
        {
            Assert.IsTrue(IsOutputFileValid1(outputPath1), "� ����� ��� ����� ��� ��� ���� ����� �����");
        }

        //���� ���, ���� �����
        [Test]
        public void F1_ZeroFishOneFishman()
        {
            string result = Helper("1 0");
            Assert.AreEqual("0", result);
        }

        //���� ���, ����� �������
        [Test]
        public void G1_ZeroFishManyFishman()
        {
            string result = Helper("50 0");
            Assert.AreEqual("0", result);
        }

        //���� ����, ���� �����
        [Test]
        public void H1_OneFishOneFishman()
        {
            string result = Helper("1 1");
            Assert.AreEqual("1", result);
        }

        //���� ����, ����� �������
        [Test]
        public void I1_OneFishManyFishman()
        {
            string result = Helper("50 1");
            Assert.AreEqual("0", result);
        }

        //����� ����, ���� �����
        [Test]
        public void J1_ManyFishOneFishman()
        {
            string result = Helper("1 30");
            Assert.AreEqual("30", result);
        }

        //��� ���� � �� ������ ���� �� �����
        [Test]
        public void K1_FewFishManyFishman()
        {
            string result = Helper("5 3");
            Assert.AreEqual("0", result);
        }

        //������ �� ����� ���� �����
        [Test]
        public void L1_ExactlyOne()
        {
            string result = Helper("5 5");
            Assert.AreEqual("1", result);
        }

        //���� ������� �� ����� ����, �� �� �������� �� ���
        [Test]
        public void M1_ExactlyOneNoTwo()
        {
            string result = Helper("5 6");
            Assert.AreEqual("1", result);
        }

        //������� �� ��� ���� �����
        [Test]
        public void N1_ExactlyTwo()
        {
            string result = Helper("5 10");
            Assert.AreEqual("2", result);
        }

        //���� �������� �� ��� ����, �� �� ������� �� ���
        [Test]
        public void O1_ExactlyTwoNoThree()
        {
            string result = Helper("5 12");
            Assert.AreEqual("2", result);
        }

        //������� �� ��� ���� �����
        [Test]
        public void P1_ExatlyThree()
        {
            string result = Helper("5 15");
            Assert.AreEqual("3", result);
        }

        //���� ������� �� ��� ����, �� �� ������� �� ������
        [Test]
        public void Q1_ExactlyThreeNoFour()
        {
            string result = Helper("5 16");
            Assert.AreEqual("3", result);
        }

        //������ 10^4 ���, 100 �������
        [Test]
        public void R1_LessFishMaxFishman()
        {
            string result = Helper("100 9999");
            Assert.AreEqual("99", result);
        }

        //10^4 ���, ������ 100 �������
        [Test]
        public void S1_MaxFishLessFishman()
        {
            string result = Helper("99 10000");
            Assert.AreEqual("101", result);
        }

        //10^4 ���, 100 �������
        [Test]
        public void T1_MaxFishMaxFishman()
        {
            string result = Helper("100 10000");
            Assert.AreEqual("100", result);
        }

        //
        //������� 4
        //

        //
        //HELP METHODS
        //

        private bool ValidateInputFromFile2(string filePath)
        {
            // ������ ��� ������ �� �����
            var lines = File.ReadAllLines(filePath);

            // ���������, ��� ���� �������� ��� ������� 3 ������
            if (lines.Length < 3) return false;

            // ��������� ������ ������ �� ������� ���� ����������� �����
            var firstLineParts = lines[0].Split(' ');
            if (firstLineParts.Length != 2) return false;

            // ���������, ��� ��� �������� - ����������� �����
            if (!uint.TryParse(firstLineParts[0], out _) || !uint.TryParse(firstLineParts[1], out _)) return false;

            // ��������� ������ ������ �� ���������� ������ ��������� ��������� ���� � ��������
            var petyaMessage = lines[1].Trim();
            if (string.IsNullOrEmpty(petyaMessage) || !petyaMessage.All(c => char.IsUpper(c) || char.IsWhiteSpace(c))) return false;

            // ��������� ������ ������ �� ���������� ������ ��������� ��������� ���� � ��������
            var newspaperText = lines[2].Trim();
            if (string.IsNullOrEmpty(newspaperText) || !newspaperText.All(c => char.IsUpper(c) || char.IsWhiteSpace(c))) return false;

            // ���� ��� �������� ��������, ���������� true
            return true;
        }
        //
        private bool IsOutputFileValid2(string filePath)
        {
            // ������ ��� ������ �� �����
            var lines = File.ReadAllLines(filePath);

            // ���������, ��� ���� �������� ����� ���� ������
            if (lines.Length != 1) return false;

            // �������� ������������ ������ � ������� ������ �������
            var input = lines[0].Trim();

            // ���������, ��� ������ ������, ���� ����� "GOOD NOTE", ���� �������� ���� �����
            return string.IsNullOrEmpty(input) || input == "GOOD NOTE" || input.Split(' ').Length == 1;
        }
        public string Helper2(string inputValue)
        {
            // �������� ��������� ������
            string inputFile = Path.GetTempFileName();
            string outputFile = Path.GetTempFileName();
            try
            {
                // ���������� ������� ������
                File.WriteAllText(inputFile, inputValue);
                // ������ ���������
                Program2.Main(new string[] { inputFile, outputFile });
                // ������ ����������
                return File.ReadAllText(outputFile).Trim();
            }
            finally
            {
                // �������� ��������� ������
                if (File.Exists(inputFile)) File.Delete(inputFile);
                if (File.Exists(outputFile)) File.Delete(outputFile);
            }
        }

        //���������� �������� NAMESPACE
        [Test]
        public void A2_Namespace()
        {
            string actualNamespace = typeof(Program2).Namespace;

            Assert.AreEqual(expectedNamespace2, actualNamespace);
        }

        //������� ����� � �������� �������
        [Test]
        public void B2_InputFileExists()
        {
            Assert.IsTrue(File.Exists(inputPath2), $"���� {inputPath2} �� ������.");
        }

        //������� ����� ��� ������ ����������
        [Test]
        public void C2_OutputFileExists()
        {

            // ��������� ������� ������
            Assert.IsTrue(File.Exists(outputPath2), $"���� {outputPath2} �� ������.");
        }

        //������������ ������� ������
        [Test]
        public void D2_InputFileDate()
        {
            Assert.IsTrue(ValidateInputFromFile2(inputPath2));
        }

        //� ������� � � ������ �� ������ �����, �������� �������

        [Test]
        public void F2_�������������������()
        {
            string result = Helper2("6 6\n������\n������");
            Assert.AreEqual("GOOD NOTE", result);
        }

        //� ������� � � ������ �� ������ �����, �������� ������
        [Test]
        public void G2_������������������()
        {
            string result = Helper2("6 6\n������\n������");
            Assert.AreEqual("������", result);
        }

        //� ������� ���� �����, � ������ �����, �������� �������
        [Test]
        public void H2_���������������()
        {
            string result = Helper2("6 23\n������\n���� ���� ������ ������");
            Assert.AreEqual("GOOD NOTE", result);
        }

        //� ������� ���� �����, � ������ �����, �������� ������
        [Test]
        public void I2_��������������()
        {
            string result = Helper2("6 16\n������\n���� ���� ������");
            Assert.AreEqual("������", result);
        }

        //� ������� � � ������ ����� ����, ������� ����� ����,��� ����������� � ������.
        [Test]
        public void J2_�������������������()
        {
            string result = Helper2("16 16\n������ ���� ����\n������ ���� ����");
            Assert.AreEqual("����", result);
        }

        //� ������� � � ������ ����� ����, ������� ����� ����,��� ������������ � ������ � ������������� ����������
        [Test]
        public void K2_�������������������������������()
        {
            string result = Helper2("21 21\n���� ���� ���� ������\n������ ���� ���� ����");
            Assert.AreEqual("����", result);
        }

        // 7-10 �������� ������� ������ � ����� ������ �������.
        //7
        [Test]
        public void L2_����������������������������_3_������()
        {
            string result = Helper2("9 138\n���������\n��� ���������� � ������������ ��������� ������� ������� ���������� ��� ���� �������� ������������ � ���� �������������� ������ �����������");
            Assert.AreEqual("GOOD NOTE", result);
        }

        //8
        [Test]
        public void M2_����������������������������_4_�����()
        {
            string result = Helper2("3 138\n���\n��� ���������� � ������������ ��������� ������� ������� ���������� ��� ���� �������� ������������ � ���� �������������� ������ �����������");
            Assert.AreEqual("���", result);
        }

        //9
        [Test]
        public void N2_����������������������������_5_���������()
        {
            string result = Helper2("18 138\n��� ���������� ��������� ���\n��� ���������� � ������������ ��������� ������� ������� ���������� ��� ���� �������� ������������ � ���� �������������� ������ �����������");
            Assert.AreEqual("���", result);
        }

        //10
        [Test]
        public void O2_����������������������������_6_��������������()
        {
            string result = Helper2("18 138\n��� ���������� ��������� ��� ���\n��� ���������� � ������������ ��������� ������� ������� ���������� ��� ���� �������� ������������ � ���� �������������� ������ �����������");
            Assert.AreEqual("���", result);
        }

        //11�14. ��������� ����� 3�6, �� �������� ������� ������ � �������.
        //11
        [Test]
        public void E2_��������������������������_3_������()
        {
            string result = Helper2("26 200\n������ ���\n������, ��� ����? ��� ������� ����� �������, � � ������, ��� ��� �������� ��� ��� ����� ������������.");
            Assert.AreEqual("GOOD NOTE", result);
        }

        //12
        [Test]
        public void P2_��������������������������_4_�����()
        {
            string result = Helper2("11 101\n������ ����\n������� ����� � ������ �����, �� ����� �� �����, ��� �Ĩ� ��� �� �����, ���� ����� ������ ��� ������.");
            Assert.AreEqual("������", result);
        }

        //13
        [Test]
        public void Q2_��������������������������_4_���������()
        {
            string result = Helper2("26 129\n������ ��� ���� ��� ������\n������ ��� ���� ��� ������� ����� �������, � � ������, ��� ��� �������� ��� ��� ����� ������������.");
            Assert.AreEqual("������", result);
        }

        //14
        [Test]
        public void R2_��������������������������_4_��������������()
        {
            string result = Helper2("26 129\n������ ��� ���� ��� ������\n������, ��� ���� ��� ������� ����� �������, � � ������, ��� ��� �������� ��� ��� ����� ������������.");
            Assert.AreEqual("������", result);
        }

        //15 - ������������ ����, �������� �������.
        [Test]
        public void S2_�����������������������()
        {
            // �������� ������, ����������� ����� �� �������
            string note = "������";
            string longText = new string('A', 9992) + " " + note;

            string inputData = $"18 {longText.Length}\n{note}\n{longText}";
            string result = Helper2(inputData);
            Assert.AreEqual("GOOD NOTE", result);
        }

        //16 - ������������ ����, �������� ������.
        [Test]
        public void T2_����������������������()
        {
            // �������� ������, ����������� ����� �� �������
            string note = "������";
            string longText = new string('A', 9992) + " ������";

            string inputData = $"18 {longText.Length}\n{note}\n{longText}";
            string result = Helper2(inputData);
            Assert.AreEqual("������", result);
        }

        //
        // 6 �������
        //

        //
        //HELP METHODS
        //

        private bool ValidateInputFromFile6(string filePath)
        {
            // ������ ��� ������ �� �����
            var lines = File.ReadAllLines(filePath);

            if (lines.Length == 1) return false;

            var firstLineParts = lines[0].Split(' ');
            if (firstLineParts.Length != 2) return false;

            if (!uint.TryParse(firstLineParts[0], out uint n) || n % 2 == 0) return false;
            if (lines.Length < n + 1) return false;
            if (!uint.TryParse(firstLineParts[1], out uint c) || c == 0) return false;

            for (int i = 1; i <= n; i++)
            {
                if (i >= lines.Length) return false;
                if (!uint.TryParse(lines[i].Trim(), out uint p) || p == 0) return false; // �������� �� ����������� �����
            }

            return true;
        }
        //
        private bool IsOutputFileValid6(string filePath)
        {

            // ������ ���������� ����� � ������� ������ �������
            var input = File.ReadAllText(filePath).Trim();

            if (string.IsNullOrEmpty(input)) return true;

            var parts = input.Split(' ');

            if (parts.Length != 1) return false;

            // ���������, ��� ������� - ����� �����
            return int.TryParse(parts[0], out _);
        }
        public string Helper6(string inputValue)
        {
            // �������� ��������� ������
            string inputFile = Path.GetTempFileName();
            string outputFile = Path.GetTempFileName();
            try
            {
                // ���������� ������� ������
                File.WriteAllText(inputFile, inputValue);
                // ������ ���������
                Program6.Main(new string[] { inputFile, outputFile });
                // ������ ����������
                return File.ReadAllText(outputFile).Trim();
            }
            finally
            {
                // �������� ��������� ������
                if (File.Exists(inputFile)) File.Delete(inputFile);
                if (File.Exists(outputFile)) File.Delete(outputFile);
            }
        }

        //
        //
        //



        //���������� �������� NAMESPACE
        [Test]
        public void A6_Namespace()
        {
            string actualNamespace = typeof(Program6).Namespace;

            Assert.AreEqual(expectedNamespace6, actualNamespace);
        }

        //������� ����� � �������� �������
        [Test]
        public void B6_InputFileExists()
        {
            Assert.IsTrue(File.Exists(inputPath6), $"���� {inputPath6} �� ������.");
        }

        //������� ����� ��� ������ ����������
        [Test]
        public void C6_OutputFileExists()
        {

            // ��������� ������� ������
            Assert.IsTrue(File.Exists(outputPath6), $"���� {outputPath6} �� ������.");
        }

        //������������ ������� ������
        [Test]
        public void D6_InputFileDate()
        {
            Assert.IsTrue(ValidateInputFromFile6(inputPath6));
        }

        //5

        [Test]
        public void E6_OutputFileDate()
        {
            Assert.IsTrue(IsOutputFileValid6(outputPath6));
        }

        //6
        [Test]
        public void G6_()
        {
            string result = Helper6("1 100\n3");
            Assert.AreEqual("200", result);
        }

        //7
        [Test]
        public void H6_()
        {
            string result = Helper6("3 10\n7\n14\n5");
            Assert.AreEqual("150", result);
        }

        //8
        [Test]
        public void I6_()
        {
            string result = Helper6("5 15\n10\n10\n10\n10\n10");
            Assert.AreEqual("450", result);
        }

        //9
        [Test]
        public void J6_�()
        {
            string result = Helper6("1 0\n10");
            Assert.AreEqual("0", result);
        }

        //10
        [Test]
        public void K6_()
        {
            string result = Helper6("1 1\n1");
            Assert.AreEqual("1", result);
        }

        //11
        [Test]
        public void L6_()
        {
            string result = Helper6("1 10\n2");
            Assert.AreEqual("20", result);
        }

        //12
        [Test]
        public void M6_()
        {
            string result = Helper6("3 5\n1\n3\n5");
            Assert.AreEqual("30", result);
        }

        //13
        [Test]
        public void N6_()
        {
            string result = Helper6("1 1000000000\n1");
            Assert.AreEqual("1000000000", result);
        }

        //14
        [Test]
        public void O6_()
        {
            string result = Helper6("3 100\n1000000\n1000000\n1000000");
            Assert.AreEqual("150000300", result);
        }

        //15
        [Test]
        public void E6_()
        {
            string result = Helper6("11 50\n1\n1\n1\n1\n1\n1\n1\n1\n1\n1\n1");
            Assert.AreEqual("550", result);
        }

        //16
        [Test]
        public void P6_()
        {
            string result = Helper6("1 100\n10000000");
            Assert.AreEqual("500000100", result);
        }

        //17
        [Test]
        public void Q6_()
        {
            string result = Helper6("3 333333333\n1\n1\n1");
            Assert.AreEqual("999999999", result);
        }

        //18
        [Test]
        public void R6_()
        {
            string result = Helper6("1 1\n0");
            Assert.AreEqual("0", result);
        }

        //19
        [Test]
        public void S6_()
        {
            string result = Helper6("1 1\n1999999999");
            Assert.AreEqual("1000000000", result);
        }

        // 20
        [Test]
        public void T6_()
        {
            string result = Helper6("7 142857142\n1\n1\n1\n1\n1\n1\n1");
            Assert.AreEqual("999999994", result);
            //}

        }
    }
}