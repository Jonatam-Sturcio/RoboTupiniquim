namespace RoboTupiniquim {
    internal class Program {
        static void Main(string[] args) {
            string movimento;
            int[] robo, limite;
            string[] txt;

            do {
                Console.WriteLine("Informe o tamanho da area no formato (2 2):");
                txt = Console.ReadLine().Split(" ");
                limite = DefinirArea(txt, 1);
            } while (limite is null);


            for (int i = 1; i <= 2; i++) {
                do {
                    Console.WriteLine($"Informe a posição inicial do robo N{i} no formato (2 2 N):");
                    txt = Console.ReadLine().Split(" ");
                    robo = DefinirArea(txt, 2);
                } while (robo is null);

                do {
                    Console.WriteLine($"Informe o movimento do robo N{i} no formato (EMDM):");
                    movimento = Console.ReadLine().ToUpper();
                    if (!((movimento.Contains("M") || (movimento.Contains("D")) || (movimento.Contains("E"))))) {
                        Console.WriteLine("Formato Invalido, tente:\nE -> Esquerda\nD -> Direita\nM - Movimentar");
                    }
                } while (!((movimento.Contains("M") || (movimento.Contains("D")) || (movimento.Contains("E")))));


                robo = RealizaMovimento(limite, robo, movimento);
                Console.WriteLine($"Localização: {robo[0]}, {robo[1]}, {RetornarDirecao(robo[2])} \n");
            }
        }
        #region
        static int[] DefinirArea(string[] txt, int modo) {
            try {
                int[] aux = [int.Parse(txt[0]), int.Parse(txt[1]), 0];
                if (modo == 2) {
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
            catch (Exception ex) {
                Console.WriteLine("Formato de Entrada Invalido, tente novamente.");
                return null;
            }
        }
        static int[] RealizaMovimento(int[] limite, int[] robo, string movimento) {
            string[] parts = movimento.ToUpper().Split("M");
            for (int i = 0; i < parts.Length - 1; i++) {
                if (parts[i].Contains("E")) {
                    robo = movimentar(robo, 1, limite);
                }
                else if (parts[i].Contains("D")) {
                    robo = movimentar(robo, 2, limite);
                }
                else {
                    robo = movimentar(robo, 0, limite);
                }
            }
            return robo;
        }
        static int[] movimentar(int[] robo, int direcao, int[] limite) {
            if (direcao == 1) {
                if (robo[2] == 1 && PermiteMovimento(limite, robo)) {
                    robo[2] = 4;
                    robo[0]--;
                }
                else if (robo[2] == 2 && PermiteMovimento(limite, robo)) {
                    robo[2]--;
                    robo[1]++;
                }
                else if (robo[2] == 3 && PermiteMovimento(limite, robo)) {
                    robo[2]--;
                    robo[0]++;
                }
                else if (robo[2] == 4 && PermiteMovimento(limite, robo)) {
                    robo[2]--;
                    robo[1]--;
                }
            }
            else if (direcao == 2) {
                if (robo[2] == 4 && PermiteMovimento(limite, robo)) {
                    robo[2] = 1;
                    robo[1]++;
                }
                else if (robo[2] == 3 && PermiteMovimento(limite, robo)) {
                    robo[2]++;
                    robo[0]--;
                }
                else if (robo[2] == 2 && PermiteMovimento(limite, robo)) {
                    robo[2]++;
                    robo[1]--;
                }
                else if (robo[2] == 1 && PermiteMovimento(limite, robo)) {
                    robo[2]++;
                    robo[0]++;
                }
            }
            else {
                if (robo[2] == 1 && PermiteMovimento(limite, robo)) {
                    robo[1]++;
                }
                else if (robo[2] == 2 && PermiteMovimento(limite, robo)) {
                    robo[0]++;
                }
                else if (robo[2] == 3 && PermiteMovimento(limite, robo)) {
                    robo[1]--;
                }
                else if (robo[2] == 4 && PermiteMovimento(limite, robo)) {
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
        static bool PermiteMovimento(int[] limite, int[] robo) {
            if (robo[0] == limite[0]) {
                Console.WriteLine("O movimento horizontal foi impedido devido a atingir o limite superior da area");
                return false;
            }
            else if (robo[1] == limite[1]) {
                Console.WriteLine("O movimento vertical foi impedido devido a atingir o limite superior da area");
                return false;
            }
            else if (robo[1] == 0) {
                Console.WriteLine("O movimento vertical foi impedido devido a atingir o limite inferior da area");
                return false;
            }
            else if (robo[0] == 0) {
                Console.WriteLine("O movimento horizontal foi impedido devido a atingir o limite inferior da area");
                return false;
            }
            else {
                return true;
            }
        }
        #endregion
    }

}
