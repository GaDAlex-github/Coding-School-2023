using CalculatorLib;

namespace Session_09 {
    public partial class Form1 : Form {

        private decimal? _value1 = null;
        private decimal? _value2 = null;
        private decimal? _result = null;

        private CalcOperation _calcOperation;

        enum CalcOperation {
            Addition,
            Subtraction,
            Multiplication,
            Division,
            Power,
            Square

        }


        public Form1() {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) {

        }


        private void button3_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += " = ";

            switch (_calcOperation) {
                case CalcOperation.Addition:
                    Addition addition = new Addition();
                    _result = addition.Do(_value1, _value2);
                    break;
                case CalcOperation.Subtraction:
                    Subtraction subtraction = new Subtraction();
                    _result = subtraction.Do(_value1, _value2);
                    break;
                case CalcOperation.Multiplication:
                    Multiplication multiplication = new Multiplication();
                    _result = multiplication.Do(_value1, _value2);
                    break;
                case CalcOperation.Division:
                    Division division = new Division();
                    _result = division.Do(_value1, _value2);
                    break;


                default:
                    break;
            }

            ctrlDisplay.Text += _result;
        }

        private void btnOne_Click(object sender, EventArgs e) {

            Result(1);
            ctrlDisplay.Text += " 1 ";

        }

        private void btnAddition_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += " + ";
            _calcOperation = CalcOperation.Addition;
        }

        private void btnTwo_Click(object sender, EventArgs e) {

            Result(2);
            ctrlDisplay.Text += " 2 ";


        }

        private void btnThree_Click(object sender, EventArgs e) {

            Result(3);
            ctrlDisplay.Text += " 3 ";


        }

        private void button1_Click(object sender, EventArgs e) {
            Result(5);
            ctrlDisplay.Text += " 5 ";
        }

        private void button1_Click_1(object sender, EventArgs e) {

        }

        private void button1_Click_2(object sender, EventArgs e) {
            ctrlDisplay.Text += " / ";
            _calcOperation = CalcOperation.Division;
        }



        private void btnFour_Click(object sender, EventArgs e) {
            Result(4);
            ctrlDisplay.Text += " 4 ";
        }

        private void btnSix_Click(object sender, EventArgs e) {
            Result(6);
            ctrlDisplay.Text += " 6 ";
        }

        private void btnSeven_Click(object sender, EventArgs e) {
            Result(7);
            ctrlDisplay.Text += " 7 ";
        }

        private void btnEight_Click(object sender, EventArgs e) {
            Result(8);
            ctrlDisplay.Text += " 8 ";
        }

        private void btnNine_Click(object sender, EventArgs e) {
            Result(9);
            ctrlDisplay.Text += " 9 ";
        }
        private void Result(int i) {
            if (_result != null) {

                ctrlDisplay.Text = string.Empty;
                _value1 = null;
                _value2 = null;
                _result = null;
            }


            if (_value1 == null) {
                _value1 = i;
            }
            else {
                _value2 = i;
            }

        }

        private void btnSubtraction_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += " - ";
            _calcOperation = CalcOperation.Subtraction;
        }

        private void btnMultiplication_Click(object sender, EventArgs e) {
            ctrlDisplay.Text += " * ";
            _calcOperation = CalcOperation.Multiplication;
        }
    }
}