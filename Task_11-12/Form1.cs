using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Task_11_12
{
    public partial class Form1 : Form
    {
        private TextBox[,] sudokuCells; // Массив для хранения ячеек судоку

        public Form1()
        {
            InitializeComponent();
            InitializeSudokuGrid(); // Инициализация сетки судоку
        }

        // Метод для инициализации сетки судоку
        private void InitializeSudokuGrid()
        {
            sudokuCells = new TextBox[9, 9]; // Создание двумерного массива для ячеек судоку
            const int cellSize = 40; // Размер ячейки

            // Создание и расположение текстовых полей для ячеек судоку
            for (int i = 0; i < sudokuCells.GetLength(0); i++)
            {
                for (int j = 0; j < sudokuCells.GetLength(1); j++)
                {
                    int squareRow = i / 3;
                    int squareCol = j / 3;
                    Color backgroundColor = (squareRow + squareCol) % 2 == 0 ? Color.Cyan : Color.White; // Определение цвета фона ячейки

                    var cell = new TextBox // Создание новой ячейки судоку
                    {
                        Location = new Point(j * cellSize + 20, i * cellSize + 20), // Установка положения ячейки на форме
                        Size = new Size(cellSize, cellSize), // Установка размера ячейки
                        Font = new Font(FontFamily.GenericSansSerif, 16), // Установка шрифта текста в ячейке
                        TextAlign = HorizontalAlignment.Center, // Установка выравнивания текста по центру
                        Multiline = true, // Включение многострочного режима для возможности ввода одного символа
                        MaxLength = 1, // Установка максимальной длины вводимого текста
                        BackColor = backgroundColor, // Установка цвета фона ячейки
                        Tag = new int[] { i, j } // Хранение координат ячейки в виде массива
                    };
                    cell.TextChanged += Cell_TextChanged; // Добавление обработчика события изменения текста
                    sudokuCells[i, j] = cell; // Добавление ячейки в массив
                    Controls.Add(cell); // Добавление ячейки на форму
                }
            }
        }

        // Метод для проверки конфликта значения в ячейке
        private bool IsConflict(int row, int col, int value)
        {
            // Проверка строки
            for (int i = 0; i < 9; i++)
            {
                if (i != col && sudokuCells[row, i].Text == value.ToString())
                    return true;
            }

            // Проверка столбца
            for (int i = 0; i < 9; i++)
            {
                if (i != row && sudokuCells[i, col].Text == value.ToString())
                    return true;
            }

            // Проверка квадрата 3x3
            int startRow = row - row % 3;
            int startCol = col - col % 3;
            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    if ((i != row || j != col) && sudokuCells[i, j].Text == value.ToString())
                        return true;
                }
            }

            return false;
        }

        // Обработчик события изменения текста в ячейке
        private void Cell_TextChanged(object sender, EventArgs e)
        {
            TextBox cell = (TextBox)sender;

            // Проверка на null
            if (cell == null)
                return;

            int row = ((int[])cell.Tag)[0]; // Получение номера строки из тега ячейки
            int col = ((int[])cell.Tag)[1]; // Получение номера столбца из тега ячейки

            // Проверяем, содержит ли текст в ячейке непустые символы и не является ли первый символ управляющим символом
            if (!string.IsNullOrEmpty(cell.Text) && !char.IsControl(cell.Text[0]))
            {
                if (!char.IsDigit(cell.Text[0]) || cell.Text[0] == '0')
                {
                    cell.Text = "";
                    return;
                }

                int value = int.Parse(cell.Text);
                if (IsConflict(row, col, value))
                {
                    // Окрашиваем конфликтные ячейки в красный
                    HighlightConflicts(row, col, Color.Red);
                }
                else
                {
                    // Окрашиваем все ячейки в зеленый, если конфликтов нет
                    HighlightConflicts(row, col, Color.Green);
                }
            }
            else
            {
                // Если ячейка пустая, сбрасываем цвет на зеленый
                HighlightConflicts(row, col, Color.Green);
            }
        }

        // Метод для выделения конфликтных ячеек определенным цветом
        private void HighlightConflicts(int row, int col, Color color)
        {
            // Окрашиваем всю строку
            for (int i = 0; i < 9; i++)
            {
                sudokuCells[row, i].ForeColor = color;
            }

            // Окрашиваем всю колонку
            for (int j = 0; j < 9; j++)
            {
                sudokuCells[j, col].ForeColor = color;
            }

            // Окрашиваем весь квадрат 3x3
            int startRow = row - row % 3;
            int startCol = col - col % 3;
            for (int i = startRow; i < startRow + 3; i++)
            {
                for (int j = startCol; j < startCol + 3; j++)
                {
                    sudokuCells[i, j].ForeColor = color;
                }
            }
        }

        /*------------------------------ События нажатий на кнопки -------------------------*/

        // Решение судоку
        private static string[] completeSudoku =
       {
            "218375469",
            "364289157",
            "579461382",
            "786932541",
            "142758936",
            "935146728",
            "421893675",
            "697524813",
            "853617294"
        };
        private void BtnShowSolution_Click(object sender, EventArgs e)
        {
            // Заполнение судоку
            for (int i = 0; i < sudokuCells.GetLength(0); i++)
            {
                for (int j = 0; j < sudokuCells.GetLength(1); j++)
                {
                    sudokuCells[i, j].Text = completeSudoku[i][j].ToString();
                }
            }
        }

        // Новая игра
        private void BtnNewGame_Click(object sender, EventArgs e)
        {
            // Очистка текстовых полей
            foreach (var cell in sudokuCells)
            {
                cell.Text = "";
            }
        }

        // Наложение условий
        private void BtnConditionImposed_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sudokuCells.GetLength(0); i++)
            {
                for (int j = 0; j < sudokuCells.GetLength(1); j++)
                {
                    if (sudokuCells[i, j].ForeColor == Color.Red)
                    {
                        MessageBox.Show("Заполните все поля правильно!");
                        return;
                    }

                    if (!string.IsNullOrEmpty(sudokuCells[i, j].Text))
                    {
                        sudokuCells[i, j].Enabled = false;
                    }
                }
            }
        }

        // Разблокировка ячеек
        private void BtnUnlockCells_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < sudokuCells.GetLength(0); i++)
            {
                for (int j = 0; j < sudokuCells.GetLength(1); j++)
                {
                    sudokuCells[i, j].Enabled = true;
                }
            }
        }

        // Сохранение состояния судоку в файл
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("sudoku_save.txt"))
                {
                    // Запись текущего состояния судоку в файл
                    for (int i = 0; i < sudokuCells.GetLength(0); i++)
                    {
                        for (int j = 0; j < sudokuCells.GetLength(1); j++)
                        {
                            if (!string.IsNullOrEmpty(sudokuCells[i, j].Text))
                            {
                                writer.Write(sudokuCells[i, j].Text);
                            }
                            else
                            {
                                writer.Write("0"); // Записываем 0 для пустых ячеек
                            }
                        }
                        writer.WriteLine(); // Переход на новую строку после каждой строки судоку
                    }
                }
                MessageBox.Show("Состояние судоку сохранено успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении состояния судоку: {ex.Message}");
            }
        }

        // Загрузка состояния судоку из файла
        private void BtnLoadSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader reader = new StreamReader("sudoku_save.txt"))
                {
                    // Чтение состояния судоку из файла
                    for (int i = 0; i < sudokuCells.GetLength(0); i++)
                    {
                        string line = reader.ReadLine();
                        if (line != null && line.Length == sudokuCells.GetLength(1))
                        {
                            for (int j = 0; j < sudokuCells.GetLength(1); j++)
                            {
                                if (line[j] != '0')
                                {
                                    sudokuCells[i, j].Text = line[j].ToString();
                                }
                                else
                                {
                                    sudokuCells[i, j].Text = ""; // Очищаем текстовое поле, если значение ячейки равно 0
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("Состояние судоку загружено успешно!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке состояния судоку: {ex.Message}");
            }
        }
    }
}
