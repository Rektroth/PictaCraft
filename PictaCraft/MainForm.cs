using System;
using System.Drawing;
using System.Windows.Forms;

namespace PictaCraft
{
    /// <summary>
    /// The window that makes up the application's main user interface.
    /// </summary>
    public partial class MainForm : Form
    {
        private Color[] blockColors =
        {
            Color.FromArgb(84, 84, 84),
            Color.FromArgb(225, 221, 201),
            Color.FromArgb(108, 88, 58),
            Color.FromArgb(147, 100, 87),
            Color.FromArgb(159, 164, 177),
            Color.FromArgb(19, 19, 19),
            Color.FromArgb(115, 115, 115),
            Color.FromArgb(119, 86, 59),
            Color.FromArgb(123, 123, 123),
            Color.FromArgb(104, 121, 104),
            Color.FromArgb(8, 10, 15),
            Color.FromArgb(45, 47, 143),
            Color.FromArgb(96, 60, 32),
            Color.FromArgb(21, 119, 136),
            Color.FromArgb(55, 58, 62),
            Color.FromArgb(73, 91, 36),
            Color.FromArgb(36, 137, 199),
            Color.FromArgb(94, 169, 25),
            Color.FromArgb(169, 48, 159),
            Color.FromArgb(224, 97, 1),
            Color.FromArgb(214, 101, 143),
            Color.FromArgb(25, 27, 32),
            Color.FromArgb(70, 73, 167),
            Color.FromArgb(126, 85, 54),
            Color.FromArgb(37, 148, 157),
            Color.FromArgb(77, 81, 85),
            Color.FromArgb(97, 119, 45),
            Color.FromArgb(74, 181, 213),
            Color.FromArgb(125, 189, 42),
            Color.FromArgb(193, 84, 185),
            Color.FromArgb(227, 132, 32),
            Color.FromArgb(229, 153, 181),
            Color.FromArgb(132, 56, 178),
            Color.FromArgb(168, 54, 51),
            Color.FromArgb(155, 155, 148),
            Color.FromArgb(226, 227, 228),
            Color.FromArgb(233, 199, 55),
            Color.FromArgb(100, 32, 156),
            Color.FromArgb(142, 33, 33),
            Color.FromArgb(125, 125, 115),
            Color.FromArgb(207, 213, 214),
            Color.FromArgb(241, 175, 21),
            Color.FromArgb(115, 95, 64),
            Color.FromArgb(119, 96, 60),
            Color.FromArgb(98, 219, 214),
            Color.FromArgb(129, 140, 143),
            Color.FromArgb(134, 96, 67),
            Color.FromArgb(123, 88, 57),
            Color.FromArgb(117, 117, 117),
            Color.FromArgb(87, 87, 87),
            Color.FromArgb(117, 117, 117),
            Color.FromArgb(87, 87, 87),
            Color.FromArgb(81, 217, 117),
            Color.FromArgb(110, 129, 116),
            Color.FromArgb(226, 231, 171),
            Color.FromArgb(221, 224, 165),
            Color.FromArgb(78, 78, 78),
            Color.FromArgb(113, 113, 113)
        };

        private const int BEDROCK = 0;
        private const int BONE_BLOCK = 1;
        private const int BOOKSHELF = 2;
        private const int BRICK = 3;
        private const int CLAY = 4;
        private const int COAL_BLOCK = 5;
        private const int COAL_ORE = 6;
        private const int COARSE_DIRT = 7;
        private const int COBBLESTONE = 8;
        private const int COBBLESTONE_MOSSY = 9;
        private const int CONCRETE_BLACK = 10;
        private const int CONCRETE_BLUE = 11;
        private const int CONCRETE_BROWN = 12;
        private const int CONCRETE_CYAN = 13;
        private const int CONCRETE_GRAY = 14;
        private const int CONCRETE_GREEN = 15;
        private const int CONCRETE_LIGHT_BLUE = 16;
        private const int CONCRETE_LIME = 17;
        private const int CONCRETE_MAGENTA = 18;
        private const int CONCRETE_ORANGE = 19;
        private const int CONCRETE_PINK = 20;
        private const int CONCRETE_POWDER_BLACK = 21;
        private const int CONCRETE_POWDER_BLUE = 22;
        private const int CONCRETE_POWDER_BROWN = 23;
        private const int CONCRETE_POWDER_CYAN = 24;
        private const int CONCRETE_POWDER_GRAY = 25;
        private const int CONCRETE_POWDER_GREEN = 26;
        private const int CONCRETE_POWDER_LIGHT_BLUE = 27;
        private const int CONCRETE_POWDER_LIME = 28;
        private const int CONCRETE_POWDER_MAGENTA = 29;
        private const int CONCRETE_POWDER_ORANGE = 30;
        private const int CONCRETE_POWDER_PINK = 31;
        private const int CONCRETE_POWDER_PURPLE = 32;
        private const int CONCRETE_POWDER_RED = 33;
        private const int CONCRETE_POWDER_SILVER = 34;
        private const int CONCRETE_POWDER_WHITE = 35;
        private const int CONCRETE_POWDER_YELLOW = 36;
        private const int CONCRETE_PURPLE = 37;
        private const int CONCRETE_RED = 38;
        private const int CONCRETE_SILVER = 39;
        private const int CONCRETE_WHITE = 40;
        private const int CONCRETE_YELLOW = 41;
        private const int CRAFTING_TABLE_FRONT = 42;
        private const int CRAFTING_TABLE_SIDE = 43;
        private const int DIAMOND_BLOCK = 44;
        private const int DIAMOND_ORE = 45;
        private const int DIRT = 46;
        private const int DIRT_PODZOL = 47;
        private const int DISPENSER_FRONT_HORIZONTAL = 48;
        private const int DISPENSER_FRONT_VERTICAL = 49;
        private const int DROPPER_FRONT_HORIZONTAL = 50;
        private const int DROPPER_FRONT_VERTICAL = 51;
        private const int EMERALD_BLOCK = 52;
        private const int EMERALD_ORE = 53;
        private const int END_BRICKS = 54;
        private const int END_STONE = 55;
        private const int FURNACE_FRONT = 56;
        private const int FURNACE_SIDE = 57;

        private PictureBoxNearestNeighbor pictureBox;

        /// <summary>
        /// Initializes an instance of the MainForm class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Recent);

            // Standard picture boxes resize images using the bicubic algorithm.
            // We need a custom picture box that resizes images using the nearest neighbor alogrithm.
            pictureBox = new PictureBoxNearestNeighbor();
            pictureBox.Name = "pictureBox";
            pictureBox.Location = new Point(13, 28);
            pictureBox.Size = new Size(599, 401);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Anchor = (AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right);
            Controls.Add(pictureBox);
        }

        private void fileOpenTool_Click(object sender, EventArgs e)
        {
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Bitmap image = new Bitmap(openFileDialog.FileName);
            pictureBox.Image = image;
            Color[,] picture = new Color[image.Size.Width, image.Size.Height];
            Bitmap newPicture = new Bitmap(image.Size.Width * 16, image.Size.Height * 16);

            for (int i = 0; i < image.Size.Width; i++)
            {
                for (int j = 0; j < image.Size.Height; j++)
                {
                    double tempCompare = 255 + 255 + 255;
                    int temp = 0;
                    picture[i, j] = image.GetPixel(i, j);

                    for (int k = 0; k < blockColors.Length; k++)
                    {
                        if (compareColors(picture[i, j], blockColors[k]) < tempCompare)
                        {
                            tempCompare = compareColors(picture[i, j], blockColors[k]);
                            temp = k;
                        }
                    }

                    image.SetPixel(i, j, blockColors[temp]);

                    using (Graphics g = Graphics.FromImage(newPicture))
                    {
                        switch (temp)
                        {
                            case BEDROCK:
                                g.DrawImage(PictaCraft.Properties.Resources.bedrock, new Point(i * 16, j * 16));
                                break;
                            case BONE_BLOCK:
                                g.DrawImage(PictaCraft.Properties.Resources.bone_block_side, new Point(i * 16, j * 16));
                                break;
                            case BOOKSHELF:
                                g.DrawImage(PictaCraft.Properties.Resources.bookshelf, new Point(i * 16, j * 16));
                                break;
                            case BRICK:
                                g.DrawImage(PictaCraft.Properties.Resources.brick, new Point(i * 16, j * 16));
                                break;
                            case CLAY:
                                g.DrawImage(PictaCraft.Properties.Resources.clay, new Point(i * 16, j * 16));
                                break;
                            case COAL_BLOCK:
                                g.DrawImage(PictaCraft.Properties.Resources.coal_block, new Point(i * 16, j * 16));
                                break;
                            case COAL_ORE:
                                g.DrawImage(PictaCraft.Properties.Resources.coal_ore, new Point(i * 16, j * 16));
                                break;
                            case COARSE_DIRT:
                                g.DrawImage(PictaCraft.Properties.Resources.coarse_dirt, new Point(i * 16, j * 16));
                                break;
                            case COBBLESTONE:
                                g.DrawImage(PictaCraft.Properties.Resources.cobblestone, new Point(i * 16, j * 16));
                                break;
                            case COBBLESTONE_MOSSY:
                                g.DrawImage(PictaCraft.Properties.Resources.cobblestone_mossy, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_BLACK:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_black, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_BLUE:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_blue, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_BROWN:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_brown, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_CYAN:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_cyan, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_GRAY:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_gray, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_GREEN:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_green, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_LIGHT_BLUE:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_light_blue, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_LIME:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_lime, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_MAGENTA:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_magenta, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_ORANGE:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_orange, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_PINK:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_pink, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_POWDER_BLACK:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_powder_black, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_POWDER_BLUE:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_powder_blue, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_POWDER_BROWN:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_powder_brown, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_POWDER_CYAN:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_powder_cyan, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_POWDER_GRAY:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_powder_gray, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_POWDER_GREEN:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_powder_green, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_POWDER_LIGHT_BLUE:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_powder_light_blue, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_POWDER_LIME:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_powder_lime, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_POWDER_MAGENTA:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_powder_magenta, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_POWDER_ORANGE:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_powder_orange, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_POWDER_PINK:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_powder_pink, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_POWDER_PURPLE:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_powder_purple, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_POWDER_RED:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_powder_red, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_POWDER_SILVER:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_powder_silver, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_POWDER_WHITE:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_powder_white, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_POWDER_YELLOW:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_powder_yellow, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_PURPLE:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_purple, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_RED:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_red, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_SILVER:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_silver, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_WHITE:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_white, new Point(i * 16, j * 16));
                                break;
                            case CONCRETE_YELLOW:
                                g.DrawImage(PictaCraft.Properties.Resources.concrete_yellow, new Point(i * 16, j * 16));
                                break;
                            case CRAFTING_TABLE_FRONT:
                                g.DrawImage(PictaCraft.Properties.Resources.crafting_table_front , new Point(i * 16, j * 16));
                                break;
                            case CRAFTING_TABLE_SIDE:
                                g.DrawImage(PictaCraft.Properties.Resources.crafting_table_side, new Point(i * 16, j * 16));
                                break;
                            case DIAMOND_BLOCK:
                                g.DrawImage(PictaCraft.Properties.Resources.diamond_block, new Point(i * 16, j * 16));
                                break;
                            case DIAMOND_ORE:
                                g.DrawImage(PictaCraft.Properties.Resources.diamond_ore, new Point(i * 16, j * 16));
                                break;
                            case DIRT:
                                g.DrawImage(PictaCraft.Properties.Resources.dirt, new Point(i * 16, j * 16));
                                break;
                            case DIRT_PODZOL:
                                g.DrawImage(PictaCraft.Properties.Resources.dirt_podzol_side, new Point(i * 16, j * 16));
                                break;
                            case DISPENSER_FRONT_HORIZONTAL:
                                g.DrawImage(PictaCraft.Properties.Resources.dispenser_front_horizontal, new Point(i * 16, j * 16));
                                break;
                            case DISPENSER_FRONT_VERTICAL:
                                g.DrawImage(PictaCraft.Properties.Resources.dispenser_front_vertical, new Point(i * 16, j * 16));
                                break;
                            case DROPPER_FRONT_HORIZONTAL:
                                g.DrawImage(PictaCraft.Properties.Resources.dropper_front_horizontal, new Point(i * 16, j * 16));
                                break;
                            case DROPPER_FRONT_VERTICAL:
                                g.DrawImage(PictaCraft.Properties.Resources.dropper_front_vertical, new Point(i * 16, j * 16));
                                break;
                            case EMERALD_BLOCK:
                                g.DrawImage(PictaCraft.Properties.Resources.emerald_block, new Point(i * 16, j * 16));
                                break;
                            case EMERALD_ORE:
                                g.DrawImage(PictaCraft.Properties.Resources.emerald_ore, new Point(i * 16, j * 16));
                                break;
                            case END_BRICKS:
                                g.DrawImage(PictaCraft.Properties.Resources.end_bricks, new Point(i * 16, j * 16));
                                break;
                            case END_STONE:
                                g.DrawImage(PictaCraft.Properties.Resources.end_stone, new Point(i * 16, j * 16));
                                break;
                            case FURNACE_FRONT:
                                g.DrawImage(PictaCraft.Properties.Resources.furnace_front_off, new Point(i * 16, j * 16));
                                break;
                            case FURNACE_SIDE:
                                g.DrawImage(PictaCraft.Properties.Resources.furnace_side, new Point(i * 16, j * 16));
                                break;
                        }
                    }
                }
            }

            pictureBox.Image = newPicture;
        }

        private double compareColors(Color c1, Color c2)
        {
            // This algorithm looks at the RGB spectrum as being a 3D space.
            // (red = x, green = y, blue = z)
            // The distance between the two colors (looked at as points in 3D space) is calculated.
            // That distance is then returned as the numerical difference between the colors.

            return Math.Sqrt(Math.Pow(c2.R - c1.R, 2) + Math.Pow(c2.G - c1.G, 2) + Math.Pow(c2.B - c1.B, 2));
        }
    }
}