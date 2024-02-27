using System;
using System.Threading;
using System.Windows.Forms;

namespace Task_13
{
    public partial class MainForm : Form
    {
        // Объявляем переменные для кнопок, представляющих лисиц
        Button fox1Button = new Button();
        Button fox2Button = new Button();

        // Счетчик съеденных куриц
        int eatenChicksCount = 0;

        // Массив игровых кнопок и объект для генерации случайных чисел
        readonly Button[,] gameButtons;
        readonly Random random = new Random();

        // Переменные для хранения текущих позиций лисиц на игровом поле
        int fox1Row = 2;
        int fox1Column = 2;
        int fox2Row = 2;
        int fox2Column = 4;

        // Конструктор формы
        public MainForm()
        {
            InitializeComponent();

            // Инициализируем кнопки лисиц и игровые кнопки
            fox1Button = (Button)Controls["button8"];
            fox2Button = (Button)Controls["button10"];

            gameButtons = new Button[7, 7]
            {
                { null, null, button0, button1, button2, null, null },
                { null, null, button3, button4, button5, null, null },
                { button6, button7, button8, button9, button10, button11, button12 },
                { button13, button14, button15, button16, button17, button18, button19 },
                { button20, button21, button22, button23, button24, button25, button26 },
                { null, null, button27, button28, button29, null, null },
                { null, null, button30, button31, button32, null, null },
            };
        }

        // Переменные для хранения выбранных кнопок начала и конца хода
        Button selectedStartButton = null;
        Button selectedEndButton = null;


        // Обработчик нажатия кнопок на игровом поле
        public void GameButton_Click(object sender, EventArgs e)
        {
            // Кнопка, на которую произошло нажатие
            Button clickedButton = (Button)sender;

            // Если выбрана курица, сохраняем ее как стартовую позицию
            if (clickedButton.Text == "К")
            {
                selectedStartButton = clickedButton;
                return;
            }

            // Если нажата кнопка с лисой, ничего не делаем
            if (clickedButton.Text == "Л")
            {
                MessageBox.Show("Перемещать можно только кур. Лис двигать нельзя!");
                return;
            }

            // Если выбрано пустое поле, сохраняем его как конечную позицию
            if (selectedStartButton != null && clickedButton.Text == "")
            {
                selectedEndButton = clickedButton;

                // Если выбранные кнопки находятся рядом, выполнить ход
                if (IsButtonsAdjacent())
                {
                    selectedStartButton.Text = "";
                    selectedEndButton.Text = "К";
                    selectedStartButton = selectedEndButton;
                    this.Refresh();

                    // Проверка победы куриц
                    if (IsChickenVictory())
                    {
                        MessageBox.Show("Вы победили", "Победа", MessageBoxButtons.OK);
                        Application.Exit();
                    }

                    Thread.Sleep(300);

                    // Проверка съедания куриц лисами
                    if (IsFoxEating())
                    {
                        if (eatenChicksCount >= 12)
                        {
                            MessageBox.Show("Лисы победили", "Проигрыш", MessageBoxButtons.OK);
                            Application.Exit();
                        }
                        return;
                    }

                    MoveFoxes();
                }
            }
        }

        // Метод для проверки, находятся ли выбранные кнопки рядом
        private bool IsButtonsAdjacent()
        {
            // Получаем значения тегов выбранных кнопок (позиции на игровом поле)
            int startButtonTag = int.Parse(selectedStartButton.Tag.ToString());
            int endButtonTag = int.Parse(selectedEndButton.Tag.ToString());

            // Проверяем, находятся ли выбранные кнопки рядом по горизонтали или вертикали
            if (startButtonTag + 1 == endButtonTag || // соседние по горизонтали справа
                startButtonTag - 1 == endButtonTag || // соседние по горизонтали слева
                startButtonTag - 10 == endButtonTag)   // соседние по вертикали вверх
            {
                return true;
            }

            return false;
        }


        // Метод для выполнения хода лисы
        private void MoveFoxes()
        {
            // Внутренний метод для осуществления перемещения лисы
            void MakeMove(ref int foxRow, ref int foxColumn, ref Button foxButton)
            {
                Button destinationButton = new Button(); // Кнопка, на которую лиса планирует переместиться

                // Бесконечный цикл для выполнения перемещения
                while (true)
                {
                    try
                    {
                        int randomDirection = random.Next(1, 5); // Генерация случайного направления движения
                        switch (randomDirection)
                        {
                            case 1: // Вверх
                                destinationButton = gameButtons[foxRow - 1, foxColumn];
                                if (destinationButton != null && destinationButton.Text == "")
                                {
                                    destinationButton.Text = foxButton.Text;
                                    foxButton.Text = "";
                                    foxRow--;
                                    break;
                                }
                                continue;

                            case 2: // Вниз
                                destinationButton = gameButtons[foxRow + 1, foxColumn];
                                if (destinationButton != null && destinationButton.Text == "")
                                {
                                    destinationButton.Text = foxButton.Text;
                                    foxButton.Text = "";
                                    foxRow++;
                                    break;
                                }
                                continue;

                            case 3: // Влево
                                destinationButton = gameButtons[foxRow, foxColumn - 1];
                                if (destinationButton != null && destinationButton.Text == "")
                                {
                                    destinationButton.Text = foxButton.Text;
                                    foxButton.Text = "";
                                    foxColumn--;
                                    break;
                                }
                                continue;

                            case 4: // Вправо
                                destinationButton = gameButtons[foxRow, foxColumn + 1];
                                if (destinationButton != null && destinationButton.Text == "")
                                {
                                    destinationButton.Text = foxButton.Text;
                                    foxButton.Text = "";
                                    foxColumn++;
                                    break;
                                }
                                continue;
                        }
                    }
                    catch (IndexOutOfRangeException)
                    {
                        continue;
                    }

                    foxButton = destinationButton; // Обновляем позицию лисы
                    return;
                }
            }

            // Выбираем случайную лису для выполнения хода
            int selectedFox = random.Next(1, 3);
            if (selectedFox == 1)
            {
                MakeMove(ref fox1Row, ref fox1Column, ref fox1Button); // Ход первой лисы
            }
            else
            {
                MakeMove(ref fox2Row, ref fox2Column, ref fox2Button); // Ход второй лисы
            }
        }


        // Метод для проверки, съедены ли курицы лисами
        private bool IsFoxEating()
        {
            int eatingCount = 0; // Счетчик съеденных куриц

            // Проверяем возможность каждой лиси съесть курицу и увеличиваем счетчик при успешном съедании
            while (CanFoxEat(ref fox1Button, ref fox1Row, ref fox1Column))
            {
                eatingCount++;
                eatenChicksCount++;
                this.Refresh();
                Thread.Sleep(500);
            }

            // Если лиса съела хотя бы одну курицу, возвращаем true
            if (eatingCount > 0)
                return true;

            // Проверяем возможность второй лиси съесть курицу
            while (CanFoxEat(ref fox2Button, ref fox2Row, ref fox2Column))
            {
                eatingCount++;
                eatenChicksCount++;
                this.Refresh();
                Thread.Sleep(500);
            }

            // Если хотя бы одна курица была съедена, возвращаем true, иначе false
            return eatingCount > 0 ? true : false;
        }


        // Проверка возможности съедания куриц лисами
        private bool CanFoxEat(ref Button foxButton, ref int foxRow, ref int foxColumn)
        {
            // Определяем позиции соседних клеток относительно текущей позиции лисы
            Button leftPosition = foxColumn - 1 >= 0 ? gameButtons[foxRow, foxColumn - 1] : null;
            Button upperPosition = foxRow - 1 >= 0 ? gameButtons[foxRow - 1, foxColumn] : null;
            Button lowerPosition = foxRow + 1 <= 6 ? gameButtons[foxRow + 1, foxColumn] : null;
            Button rightPosition = foxColumn + 1 <= 6 ? gameButtons[foxRow, foxColumn + 1] : null;

            // Проверяем каждую из возможных позиций на наличие курицы и свободное поле за ней
            if (leftPosition != null && leftPosition.Text == "К")
            {
                if (foxColumn - 2 >= 0 && gameButtons[foxRow, foxColumn - 2] != null && gameButtons[foxRow, foxColumn - 2].Text == "")
                {
                    // Лиса съедает курицу, перемещается на свободное место и удаляет курицу с поля
                    gameButtons[foxRow, foxColumn - 2].Text = "Л";
                    foxButton.Text = "";
                    foxButton = gameButtons[foxRow, foxColumn - 2];
                    leftPosition.Text = "";
                    foxColumn -= 2;
                    return true;
                }
            }
            if (upperPosition != null && upperPosition.Text == "К")
            {
                if (foxRow - 2 >= 0 && gameButtons[foxRow - 2, foxColumn] != null && gameButtons[foxRow - 2, foxColumn].Text == "")
                {
                    gameButtons[foxRow - 2, foxColumn].Text = "Л";
                    foxButton.Text = "";
                    foxButton = gameButtons[foxRow - 2, foxColumn];
                    upperPosition.Text = "";
                    foxRow -= 2;
                    return true;
                }
            }
            if (lowerPosition != null && lowerPosition.Text == "К")
            {
                if (foxRow + 2 <= 6 && gameButtons[foxRow + 2, foxColumn] != null && gameButtons[foxRow + 2, foxColumn].Text == "")
                {
                    gameButtons[foxRow + 2, foxColumn].Text = "Л";
                    foxButton.Text = "";
                    foxButton = gameButtons[foxRow + 2, foxColumn];
                    lowerPosition.Text = "";
                    foxRow += 2;
                    return true;
                }
            }
            if (rightPosition != null && rightPosition.Text == "К")
            {
                if (foxColumn + 2 <= 6 && gameButtons[foxRow, foxColumn + 2] != null && gameButtons[foxRow, foxColumn + 2].Text == "")
                {
                    gameButtons[foxRow, foxColumn + 2].Text = "Л";
                    foxButton.Text = "";
                    foxButton = gameButtons[foxRow, foxColumn + 2];
                    rightPosition.Text = "";
                    foxColumn += 2;
                    return true;
                }
            }
            return false;
        }

        // Проверка победы куриц
        private bool IsChickenVictory()
        {
            if (button0.Text == "К" &&
                button1.Text == "К" &&
                button2.Text == "К" &&
                button3.Text == "К" &&
                button4.Text == "К" &&
                button5.Text == "К" &&
                button8.Text == "К" &&
                button9.Text == "К" &&
                button10.Text == "К")
            {
                return true;
            }

            return false;
        }
    }
}
