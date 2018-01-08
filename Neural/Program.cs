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

            int setCount = 1;
            float E = 0.7f; //скорость обучения
            float A = 0.3f; //момент

            float input1 = 1;
            float input2 = 0;
            float O1ideal = 1;
            
            float w1 = 0.45f;
            float w2 = 0.78f;
            float w3 = -0.12f;
            float w4 = 0.13f;
            float w5 = 1.5f;
            float w6 = -2.3f;


            Console.WriteLine("");
            Console.WriteLine("Расчет выходного значения сети");


            float H1input = input1 * w1 + input2 * w3; //вход для H1
            float H1output = 1 / (1 + (float) Math.Exp(-H1input)); //выход из H1
            Console.WriteLine("H1input = " + H1input);
            Console.WriteLine("H1output = " + H1output);

            float H2input = input1 * w2 + input2 * w4;
            float H2output = 1 / (1 + (float)Math.Exp(-H2input));
            Console.WriteLine("H2input = " + H2input);
            Console.WriteLine("H2output = " + H2output);

            float O1input = H1output * w5 + H2output * w6;
            float O1output = 1 / (1 + (float)Math.Exp(-O1input));
            Console.WriteLine("O1input = " + O1input);
            Console.WriteLine("O1output = " + O1output);

            float error = (float) Math.Pow( (O1ideal - O1output), 2 ) / setCount; //Mean Squared Error (далее MSE)
            Console.WriteLine("error = " + error);


            Console.WriteLine("");
            Console.WriteLine("Расчет дельты, градиента и смещение весов");


            float deltaO1 = (O1ideal - O1output) * ((O1ideal - O1output) * O1output); //дельта для выходного нейрона
            Console.WriteLine("deltaO1 = " + deltaO1);


            float deltaH1 = ( (O1ideal - H1output) * H1output ) * (w5 * deltaO1); //дельта для скрытого уровня имеющего и вход и выход
            Console.WriteLine("deltaH1 = " + deltaH1);

            float GRADw5 = H1output * deltaO1; //градиент
            Console.WriteLine("GRADw5 = " + GRADw5);
             
            float delta_w5 = E * GRADw5 + 0 * A; //здесь 0 заменить на вычисление предыдущего шага Δw5(i-1) = 0
            Console.WriteLine("delta_w5 = " + delta_w5);

            w5 = w5 + delta_w5; //смещение веса на дельту, расчитанную по градиенту
            Console.WriteLine("w5 = " + w5);


            float deltaH2 = ((O1ideal - H2output) * H2output) * (w6 * deltaO1);
            Console.WriteLine("deltaH2 = " + deltaH2);

            float GRADw6 = H2output * deltaO1;
            Console.WriteLine("GRADw6 = " + GRADw6);

            float delta_w6 = E * GRADw6 + 0 * A; //здесь 0 заменить на вычисление предыдущего шага Δw6(i-1) = 0
            Console.WriteLine("delta_w6 = " + delta_w6);

            w6 = w6 + delta_w6;
            Console.WriteLine("w6 = " + w6);


            //не нужно находить дельты для входных нейронов так как у них нет входных синапсов

            float GRADw1 = input1 * deltaH1;
            Console.WriteLine("GRADw1 = " + GRADw1);

            float GRADw2 = input1 * deltaH2;
            Console.WriteLine("GRADw2 = " + GRADw2);

            float GRADw3 = input2 * deltaH1;
            Console.WriteLine("GRADw3 = " + GRADw3);

            float GRADw4 = input2 * deltaH2;
            Console.WriteLine("GRADw4 = " + GRADw4);


            float delta_w1 = E * GRADw1 + 0 * A; //здесь 0 заменить на вычисление предыдущего шага Δw1(i-1) = 0
            Console.WriteLine("delta_w1 = " + delta_w1);

            float delta_w2 = E * GRADw2 + 0 * A; //здесь 0 заменить на вычисление предыдущего шага Δw1(i-1) = 0
            Console.WriteLine("delta_w2 = " + delta_w2);

            float delta_w3 = E * GRADw3 + 0 * A; //здесь 0 заменить на вычисление предыдущего шага Δw1(i-1) = 0
            Console.WriteLine("delta_w3 = " + delta_w3);

            float delta_w4 = E * GRADw4 + 0 * A; //здесь 0 заменить на вычисление предыдущего шага Δw1(i-1) = 0
            Console.WriteLine("delta_w4 = " + delta_w4);


            w1 = w1 + delta_w1;
            Console.WriteLine("w1 = " + w1);

            w2 = w2 + delta_w2;
            Console.WriteLine("w2 = " + w2);

            w3 = w3 + delta_w3;
            Console.WriteLine("w3 = " + w3);

            w4 = w4 + delta_w4;
            Console.WriteLine("w4 = " + w4);


            Console.WriteLine("");
            Console.WriteLine("Пересчитываем выход с новыми весами");


            H1input = input1 * w1 + input2 * w3; //вход для H1
            H1output = 1 / (1 + (float)Math.Exp(-H1input)); //выход из H1
            Console.WriteLine("H1input = " + H1input);
            Console.WriteLine("H1output = " + H1output);

            H2input = input1 * w2 + input2 * w4;
            H2output = 1 / (1 + (float)Math.Exp(-H2input));
            Console.WriteLine("H2input = " + H2input);
            Console.WriteLine("H2output = " + H2output);

            O1input = H1output * w5 + H2output * w6;
            O1output = 1 / (1 + (float)Math.Exp(-O1input));
            Console.WriteLine("O1input = " + O1input);
            Console.WriteLine("O1output = " + O1output);

            error = (float)Math.Pow((O1ideal - O1output), 2) / setCount;
            Console.WriteLine("error = " + error);


            Console.ReadKey();
        }
    }
}
