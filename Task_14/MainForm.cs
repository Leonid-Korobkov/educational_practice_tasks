using System;
using System.Drawing;
using System.Windows.Forms;

namespace Task_14
{
    public partial class MainForm : Form
    {
        // Переменные для хранения размера сетки, интервала обновления и состояний заражения клеток
        private int gridSize;
        private int interval;
        private int[,] infectionTicks;
        private CellPanel[,] gridPanels;
        private bool isSimulationRunning = false;

        // Количество тиков заражения и иммунитета
        private int amountInfectionTicks = 6;
        private int amountImmunTicks = 4;

        private Random random = new Random();

        public MainForm()
        {
            InitializeComponent();
        }

        // Обновление настроек сетки и таймера
        private void UpdateSettings()
        {
            interval = (int)inputIntervalTimeMs.Value;
            gridSize = (int)inputSizeN.Value;

            timer.Interval = interval;
        }

        // Включение/выключение элементов управления настроками симуляции
        private void ToggleSettingsEnabled(bool isEnabled)
        {
            inputSizeN.Enabled = isEnabled;
            inputIntervalTimeMs.Enabled = isEnabled;
        }

        // Включение/выключение элементов управления симуляцией
        private void ToggleSimulationControlsEnabled(bool isRunning)
        {
            btnStart.Enabled = !isRunning;
            btnStop.Enabled = isRunning;
            ToggleSettingsEnabled(!isRunning);
        }

        // Начало симуляции
        private void StartSimulation()
        {
            isSimulationRunning = true;
            UpdateSettings();

            // Вычисление размера каждой ячейки сетки
            int panelSize = 100 / (gridSize / 3);

            // Инициализация массивов для хранения количества тиков времени и состояний клеток
            infectionTicks = new int[gridSize, gridSize];
            gridPanels = new CellPanel[gridSize, gridSize];

            // Создание ячеек сетки и их добавление на форму
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    infectionTicks[i, j] = 0;
                    gridPanels[i, j] = new CellPanel()
                    {
                        Size = new Size(panelSize, panelSize),
                        Location = new Point((5 + panelSize) * i, (5 + panelSize) * j)
                    };
                    Controls.Add(gridPanels[i, j]);
                }
            }

            // Установка исходной зараженной клетки
            gridPanels[gridSize / 2, gridSize / 2].State = CellState.Infected;
            timer.Start();

            // Включение/выключение элементов управления
            ToggleSimulationControlsEnabled(true);
        }

        // Остановка симуляции
        private void StopSimulation()
        {
            isSimulationRunning = false;
            // Удаление всех ячеек с формы
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    Controls.Remove(gridPanels[i, j]);
                }
            }
            timer.Stop();

            // Включение/выключение элементов управления
            ToggleSimulationControlsEnabled(false);
        }

        // Обработчик нажатия кнопки "Start"
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (!isSimulationRunning)
            {
                StartSimulation();
            }
        }

        // Обработчик нажатия кнопки "Stop"
        private void btnStop_Click(object sender, EventArgs e)
        {
            if (isSimulationRunning)
            {
                StopSimulation();
            }
        }

        // Обработчик события таймера, отвечающий за процесс симуляции
        private void timer_Tick(object sender, EventArgs e)
        {
            // Обход всех клеток сетки
            for (int i = 0; i < gridSize; i++)
            {
                for (int j = 0; j < gridSize; j++)
                {
                    // Увеличение счетчика заражения для всех нездоровых клеток
                    if (gridPanels[i, j].State != CellState.Healthy)
                        infectionTicks[i, j]++;

                    // Попытка заражения соседних клеток
                    int randomValue = random.Next(2);
                    if (gridPanels[i, j].State == CellState.Infected)
                    {
                        if (randomValue == 1)
                            TryInfect(i, j);
                    }

                    // Проверка состояния зараженности клетки
                    CheckInfectionTicks(i, j);
                }
            }
        }

        // Попытка заражения соседних клеток
        private void TryInfect(int x, int y)
        {
            int[,] neighbors = { { x + 1, y }, { x - 1, y }, { x, y - 1 }, { x, y + 1 } };

            for (int i = 0; i < neighbors.GetLength(0); i++)
            {
                int randomIndex = random.Next(4);
                int newX = neighbors[randomIndex, 0];
                int newY = neighbors[randomIndex, 1];

                if (IsValidCoordinate(newX, newY) && gridPanels[newX, newY].State == CellState.Healthy)
                {
                    gridPanels[newX, newY].State = CellState.Infected;
                }
            }
        }

        // Проверка допустимости координат клетки
        private bool IsValidCoordinate(int x, int y)
        {
            return (x >= 0 && y >= 0 && x < gridSize && y < gridSize);
        }

        // Обработка счетчика заражения для клетки
        private void CheckInfectionTicks(int x, int y)
        {
            CellState cellState = gridPanels[x, y].State;

            // Если клетка заражена и прошло достаточно времени, изменить состояние на иммунное
            if (cellState == CellState.Infected && infectionTicks[x, y] >= amountInfectionTicks)
            {
                gridPanels[x, y].State = CellState.Immune;
                infectionTicks[x, y] = 0;
            }
            // Если клетка иммунна и прошло достаточно времени, изменить состояние на здоровое
            else if (cellState == CellState.Immune && infectionTicks[x, y] >= amountImmunTicks)
            {
                gridPanels[x, y].State = CellState.Healthy;
                infectionTicks[x, y] = 0;
            }
        }
    }

    // Перечисление для состояния клетки
    public enum CellState
    {
        Healthy,
        Infected,
        Immune
    }

    // Пользовательский класс для панели клетки
    public class CellPanel : Panel
    {
        // Свойство для хранения состояния клетки
        private CellState state;

        // Свойство для доступа к состоянию клетки
        public CellState State
        {
            get { return state; }
            set
            {
                state = value;
                UpdateColor(); // Обновление цвета панели при изменении состояния
            }
        }

        // Конструктор класса, устанавливает исходное состояние и цвет панели
        public CellPanel()
        {
            state = CellState.Healthy;
            UpdateColor();
        }

        // Обновление цвета панели в зависимости от состояния клетки
        private void UpdateColor()
        {
            switch (state)
            {
                case CellState.Healthy:
                    this.BackColor = Color.White;
                    break;
                case CellState.Infected:
                    this.BackColor = Color.Red;
                    break;
                case CellState.Immune:
                    this.BackColor = Color.Green;
                    break;
            }
        }
    }
}
