using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Neural
{
    class Program
    {
        static void Main(string[] args)
        {

            //         w1  
            // input1  w2  H1 w7
            //         w3  
            //             H2 w8   O1
            //         w4
            // input2  w5  H3 w9
            //         w6


            int counter = 1; //счетчик сетов
            int setCount = 1; //количество сетов
            float E = 0.7f; //скорость обучения
            float A = 0.3f; //момент

            float input1 = 1;
            float input2 = 0;
            float O1ideal = 1;
            
            float w1 = -1f;
            float w2 =  1f;
            float w3 =  1f;

            float w4 =  1f;
            float w5 = -1f;
            float w6 =  1f;

            float w7 =  2f;
            float w8 =  2f;
            float w9 = -1f;

            float delta_w1_old = 0;
            float delta_w2_old = 0;
            float delta_w3_old = 0;
            float delta_w4_old = 0;
            float delta_w5_old = 0;
            float delta_w6_old = 0;
            float delta_w7_old = 0;
            float delta_w8_old = 0;
            float delta_w9_old = 0;

           
            float H1input;
            float H1output;
           
            float H2input;
            float H2output;

            float H3input;
            float H3output;

            float O1input;
            float O1output;
           
            float error;
           

        mark1:
            if (counter == 1)
            {
                input1 = 1;
                input2 = 0;
                O1ideal = 1;
            }
            if (counter == 2)
            {
                input1 = 0;
                input2 = 1;
                O1ideal = 1;
            }
            if (counter == 3)
            {
                input1 = 1;
                input2 = 1;
                O1ideal = 0;
            }
            if (counter == 4)
            {
                input1 = 0;
                input2 = 0;
                O1ideal = 0;
            }

            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("input1 = " + input1 + ", input2 = " + input2 + ", O1ideal = " + O1ideal);


            Console.WriteLine("");
            Console.WriteLine("Считаем выход на старте цикла");
            Console.WriteLine("");

            H1input = input1 * w1 + input2 * w4;
            //H1output = 1 / (1 + (float)Math.Exp(-H1input));
            H1output = H1input;
            Console.WriteLine("H1input = " + H1input);
            Console.WriteLine("H1output = " + H1output);

            H2input = input1 * w2 + input2 * w5;
            //H2output = 1 / (1 + (float)Math.Exp(-H2input));
            H2output = H2input;
            Console.WriteLine("H2input = " + H2input);
            Console.WriteLine("H2output = " + H2output);

            H3input = input1 * w3 + input2 * w6;
            //H3output = 1 / (1 + (float)Math.Exp(-H3input));
            H3output = H3input;
            Console.WriteLine("H3input = " + H3input);
            Console.WriteLine("H3output = " + H3output);

            O1input = H1output * w7 + H2output * w8 + H3output * w9;
            //O1output = 1 / (1 + (float)Math.Exp(-O1input));
            O1output = O1input;
            Console.WriteLine("O1input = " + O1input);
            Console.WriteLine("O1output = " + O1output);

            error = (float)Math.Pow((O1ideal - O1output), 2) / setCount;
            Console.WriteLine("error = " + error);

    
            /*
            Console.WriteLine("");
            Console.WriteLine("Считаем дельту, градиент и корректируем веса");
            Console.WriteLine("");

            float deltaO1 = (O1ideal - O1output) * ((O1ideal - O1output) * O1output); //дельта для выходного нейрона
            Console.WriteLine("deltaO1 = " + deltaO1);


            float deltaH1 = ( (O1ideal - H1output) * H1output ) * (w7 * deltaO1); //дельта для скрытого уровня имеющего и вход и выход
            Console.WriteLine("deltaH1 = " + deltaH1);

            float GRADw7 = H1output * deltaO1; //градиент
            Console.WriteLine("GRADw7 = " + GRADw7);
             
            float delta_w7 = E * GRADw7 + delta_w7_old * A;
            delta_w7_old = delta_w7;
            Console.WriteLine("delta_w7 = " + delta_w7);

            w7 = w7 + delta_w7; //смещение веса на дельту, расчитанную по градиенту
            Console.WriteLine("w7 = " + w7);



            float deltaH2 = ((O1ideal - H2output) * H2output) * (w8 * deltaO1);
            Console.WriteLine("deltaH2 = " + deltaH2);

            float GRADw8 = H2output * deltaO1;
            Console.WriteLine("GRADw8 = " + GRADw8);

            float delta_w8 = E * GRADw8 + delta_w8_old * A;
            delta_w8_old = delta_w8;
            Console.WriteLine("delta_w8 = " + delta_w8);

            w8 = w8 + delta_w8;
            Console.WriteLine("w8 = " + w8);



            float deltaH3 = ((O1ideal - H3output) * H3output) * (w9 * deltaO1);
            Console.WriteLine("deltaH3 = " + deltaH3);

            float GRADw9 = H3output * deltaO1;
            Console.WriteLine("GRADw9 = " + GRADw9);

            float delta_w9 = E * GRADw9 + delta_w9_old * A;
            delta_w9_old = delta_w9;
            Console.WriteLine("delta_w9 = " + delta_w9);

            w9 = w9 + delta_w9;
            Console.WriteLine("w9 = " + w9);


            //не нужно находить дельты для входных нейронов так как у них нет входных синапсов

            float GRADw1 = input1 * deltaH1;
            Console.WriteLine("GRADw1 = " + GRADw1);

            float GRADw2 = input1 * deltaH2;
            Console.WriteLine("GRADw2 = " + GRADw2);

            float GRADw3 = input1 * deltaH3;
            Console.WriteLine("GRADw3 = " + GRADw3);

            float GRADw4 = input2 * deltaH1;
            Console.WriteLine("GRADw4 = " + GRADw4);

            float GRADw5 = input2 * deltaH2;
            Console.WriteLine("GRADw5 = " + GRADw5);

            float GRADw6 = input2 * deltaH3;
            Console.WriteLine("GRADw6 = " + GRADw6);


            float delta_w1 = E * GRADw1 + delta_w1_old * A;
            delta_w1_old = delta_w1;
            Console.WriteLine("delta_w1 = " + delta_w1);

            float delta_w2 = E * GRADw2 + delta_w2_old * A;
            delta_w2_old = delta_w2;
            Console.WriteLine("delta_w2 = " + delta_w2);

            float delta_w3 = E * GRADw3 + delta_w3_old * A;
            delta_w3_old = delta_w3;
            Console.WriteLine("delta_w3 = " + delta_w3);

            float delta_w4 = E * GRADw4 + delta_w4_old * A;
            delta_w4_old = delta_w4;
            Console.WriteLine("delta_w4 = " + delta_w4);

            float delta_w5 = E * GRADw5 + delta_w5_old * A;
            delta_w5_old = delta_w5;
            Console.WriteLine("delta_w5 = " + delta_w5);

            float delta_w6 = E * GRADw6 + delta_w6_old * A;
            delta_w6_old = delta_w6;
            Console.WriteLine("delta_w6 = " + delta_w6);


            w1 = w1 + delta_w1;
            Console.WriteLine("w1 = " + w1);

            w2 = w2 + delta_w2;
            Console.WriteLine("w2 = " + w2);

            w3 = w3 + delta_w3;
            Console.WriteLine("w3 = " + w3);

            w4 = w4 + delta_w4;
            Console.WriteLine("w4 = " + w4);

            w5 = w5 + delta_w5;
            Console.WriteLine("w5 = " + w5);

            w6 = w6 + delta_w6;
            Console.WriteLine("w6 = " + w6);



            Console.WriteLine("");
            Console.WriteLine("Пересчитываем выход с новыми весами");

            H1input = input1 * w1 + input2 * w4;
            H1output = 1 / (1 + (float)Math.Exp(-H1input));
            Console.WriteLine("H1input = " + H1input);
            Console.WriteLine("H1output = " + H1output);

            H2input = input1 * w2 + input2 * w5;
            H2output = 1 / (1 + (float)Math.Exp(-H2input));
            Console.WriteLine("H2input = " + H2input);
            Console.WriteLine("H2output = " + H2output);

            H3input = input1 * w3 + input2 * w6;
            H3output = 1 / (1 + (float)Math.Exp(-H3input));
            Console.WriteLine("H3input = " + H3input);
            Console.WriteLine("H3output = " + H3output);

            O1input = H1output * w7 + H2output * w8 + H3output * w9;
            O1output = 1 / (1 + (float)Math.Exp(-O1input));
            Console.WriteLine("O1input = " + O1input);
            Console.WriteLine("O1output = " + O1output);

            error = (float)Math.Pow((O1ideal - O1output), 2) / setCount;
            Console.WriteLine("error = " + error);

    */
            Console.ReadKey();

            counter += 1;
            if (counter == 5) counter = 1;

            goto mark1;
        }
    }
}
