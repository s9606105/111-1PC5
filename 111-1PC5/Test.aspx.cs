using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _111_1PC5
{
    public partial class Test : System.Web.UI.Page
    {
        int[] ia_total = new int[8];
        int[] ia_number = new int[]
        {
                10000, 36, 720, 360, 80,
                252, 108, 72, 54, 180,
                72, 180, 119, 36, 306,
                1080, 144, 1800, 3600
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            int[,] ia_Lottery = new int[3, 3]
            {
                { 7, 8, 9 },
                { 1, 4, 3 },
                { 2, 5, 6 }
            };
            // read 2D, write possible numbers
            for (int i_row = 0; i_row < ia_Lottery.GetLength(0); i_row++)
            {
                for (int i_col = 0; i_col < ia_Lottery.GetLength(1); i_col++)
                {
                    // add 1-6
                    ia_total[i_row] += ia_Lottery[i_row, i_col];
                    ia_total[i_row + 3] += ia_Lottery[i_col, i_row];

                    // Handling exceptions, center X, 7-8
                    if ((i_row == 0 && i_col == 0) || (i_row == 1 && i_col == 1)
                        || (i_row == 2 && i_col == 2))
                        ia_total[6] += ia_Lottery[i_row, i_col];
                    if ((i_row == 0 && i_col == 2) || (i_row == 1 && i_col == 1)
                        || (i_row == 2 && i_col == 0))
                        ia_total[7] += ia_Lottery[i_row, i_col];
                }
            }

            mt_GetMost();
            Response.Write("<br>");
            mt_GetLeast();
        }

        void mt_GetMost()
        {
            int mostSum = 0, mostMoney = 0;

            for (int i_in = 0; i_in < ia_total.Length; i_in++)
            {
                //Response.Write(ia_total[i_in] + "<br>");
                if (mostMoney < ia_number[ia_total[i_in] - 6])
                {
                    mostSum = ia_total[i_in];
                    mostMoney = ia_number[ia_total[i_in] - 6];
                }
            }
            Response.Write("mostSum: " + mostSum + ", mostMGP: " + mostMoney + "元");
        }

        void mt_GetLeast()
        {
            int leastSum = 0, leastMoney = 0;

            for (int i_in = 0; i_in < ia_total.Length; i_in++)
            {
                if (i_in == 0)
                {
                    leastSum = ia_total[i_in];
                    leastMoney = ia_number[ia_total[i_in] - 6];
                }
                else if (leastMoney > ia_number[ia_total[i_in] - 6])
                {
                    leastSum = ia_total[i_in];
                    leastMoney = ia_number[ia_total[i_in] - 6];
                }
            }
            Response.Write("leastSum: " + leastSum + ", leastMGP: " + leastMoney + "元");
        }
    }
}