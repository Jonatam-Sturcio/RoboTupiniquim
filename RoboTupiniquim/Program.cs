namespace RoboTupiniquim {
    internal class Program {
        static void Main(string[] args) {
            string movimento;
            int[] robo, limite;
            string[] txt;

            Console.WriteLine("Informe o tamanho da area no formato (2 2):");
            txt = Console.ReadLine().Split(" ");
            limite = DefinirArea(txt);

            Console.WriteLine("Informe a posição inicial do robo no formato (2 2 N):");
            txt = Console.ReadLine().Split(" ");
            robo = DefinirArea(txt);

            Console.WriteLine("Informe o movimento do robo no formato (EMDM):");
            movimento = Console.ReadLine().ToUpper();

            robo = RealizaMovimento(limite, robo, movimento);
            Console.WriteLine($"Localização: {robo[0]}, {robo[1]}, {RetornarDirecao(robo[2])} ");
            //1 - Norte / 2 - Leste / 3 - Sul / 4 - Oeste
        }
        static int[] DefinirArea(string[] txt) {
            int[] aux = [int.Parse(txt[0]), int.Parse(txt[1]), 0];
            if (txt.Length > 2) {
                if ("N".Equals(txt[2].ToUpper())) {
                    aux[2] = 1;
                }
                else if ("L".Equals(txt[2].ToUpper())) {
                    aux[2] = 2;
                }
                else if ("S".Equals(txt[2].ToUpper())) {
                    aux[2] = 3;
                }
                else if ("O".Equals(txt[2].ToUpper())) {
                    aux[2] = 4;
                }
            }
            return aux;
        }
        static int[] RealizaMovimento(int[] limite, int[] robo, string movimento) {
            string[] parts = movimento.ToUpper().Split("M");
            for (int i = 0; i < parts.Length - 1; i++) {
                Console.WriteLine(i);
                if (parts[i].Contains("E")) {
                    robo = movimentar(robo, 1);
                }
                else if (parts[i].Contains("D")) {
                    robo = movimentar(robo, 2);
                }
                else {
                    robo = movimentar(robo, 0);
                }
            }
            return robo;
        }
        static int[] movimentar(int[] robo, int direcao) {
            if (direcao == 1) {
                if (robo[2] == 1) {
                    robo[2] = 4;
                    robo[0]--;
                }
                else if (robo[2] == 2) {
                    robo[2]--;
                    robo[1]++;
                }
                else if (robo[2] == 3) {
                    robo[2]--;
                    robo[0]++;
                }
                else if (robo[2] == 4) {
                    robo[2]--;
                    robo[1]--;
                }
            }
            else if (direcao == 2) {
                if (robo[2] == 4) {
                    robo[2] = 1;
                    robo[1]++;
                }
                else if (robo[2] == 3) {
                    robo[2]++;
                    robo[0]--;
                }
                else if (robo[2] == 2) {
                    robo[2]++;
                    robo[1]--;
                }
                else if (robo[2] == 1) {
                    robo[2]++;
                    robo[0]++;
                }
            }
            else {
                if (robo[2] == 1) {
                    robo[1]++;
                }
                else if (robo[2] == 2) {
                    robo[0]++;
                }
                else if (robo[2] == 3) {
                    robo[1]--;
                }
                else if (robo[2] == 4) {
                    robo[0]--;
                }
            }
            return robo;
        }
        static string RetornarDirecao(int valor) {
            switch (valor) {
                case 1:
                    return "N";
                case 2:
                    return "L";
                case 3:
                    return "S";
                case 4:
                    return "O";
                default: return "";
            }
        }
    }

}
