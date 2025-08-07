using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;

public class vampireGame
{
    public static void Main(string[] args)
    {
        //VARIÁVEIS DO PROJETO
        int physicalAttribute = 3; //Seu bônus de Atributo Físico
        int stealthSkill = 2; //Nível da Habilidade, Furtividade
        int stealthAction = physicalAttribute + stealthSkill; //Bônus total
        int testDifficulty = 3; //Dificuldade padrão dos Testes
        int normalSuccess = 0; //Resultado das rolagens normais
        int criticalSuccess = 0; //Resultado das rolagens críticas
        int tensCounter = 0; //Conta resultados 10 nos testes
        int totalSuccesses = 0; //Soma dos sucessos normais e críticos
        
        //###############################################################
        
        //TÍTULO DDO JOGO
        Dictionary<char, string[]> letras = new Dictionary<char, string[]>
        {
            { 'T', new[] {
                "#####",
                "  #  ",
                "  #  ",
                "  #  ",
                "  #  "
            }},
            { 'H', new[] {
                "#   #",
                "#   #",
                "#####",
                "#   #",
                "#   #"
            }},
            { 'E', new[] {
                "#####",
                "#    ",
                "#####",
                "#    ",
                "#####"
            }},
            { 'U', new[] {
                "#   #",
                "#   #",
                "#   #",
                "#   #",
                "#####"
            }},
            { 'N', new[] {
                "#   #",
                "##  #",
                "# # #",
                "#  ##",
                "#   #"
            }},
            { ' ', new[] {
                "     ",
                "     ",
                "     ",
                "     ",
                "     "
            }}
        };

        string texto = "THE HUNT";

        for (int linha = 0; linha < 5; linha++)
        {
            foreach (char letra in texto)
            {
                if (letras.ContainsKey(letra))
                {
                    Console.Write(letras[letra][linha] + "  ");
                }
            }
            Console.WriteLine();
        }
        
        //###############################################################
        
        //INÍCIO DA CENA
        Console.WriteLine("\n");
        string narration1 = "It's late at night. You're walking the streets of Santa Monica, Los Angeles, as Hunger mercilessly attacks you. In a dark alley near Trip's Pawn Shop, you notice a homeless man seeking refuge from the cold. This is the perfect opportunity to hunt, but you have to sneak up on him.";
        
        // Escreve a mensagem letra à letra.
        foreach (char letra in narration1)
        {
            Console.Write(letra);
            Thread.Sleep(100); 
        }
        
        //###############################################################
        
        //SISTEMA DE ROLAGEM
         Console.Write($"\n\nPress ENTER to make a Stealth Test (Level {physicalAttribute + stealthSkill}), Difficulty = {testDifficulty}");
         Console.ReadLine();
         
         //Método de rolagem de dados com base no nível da Ação
         Random dicePool = new Random();
         List<int> testResults = new List<int>();
         for(int i = 0; i < stealthAction; i++){
             int roll = dicePool.Next(1, 11);
             testResults.Add(roll);
             if(roll >= 6) {normalSuccess += 1;}
         }
         
         //Contabiliza os 10 para calcular sucesso crítico
         foreach(int result in testResults) {
             if(result == 10) {tensCounter += 1;}
         }
         criticalSuccess = (tensCounter / 2) * 2;
        
         //Determina o Sucesso Total
         totalSuccesses = normalSuccess + criticalSuccess;
         
         //Ordena a lista de resultados do maior pro menor
         testResults.Sort();
         testResults.Reverse();
         
         //###############################################################
         
         //RESULTADO DA ROLAGEM
         List<string> showResults = new List<string>();
         foreach(int value in testResults) {
            if (value == 10) {showResults.Add($"**{value}**");}
            else if (value >= 6 && value < 10) {showResults.Add($"*{value}*");}
            else if (value < 6) {showResults.Add($"|{value}|");}
            else {showResults.Add("ERROR!!!");}
         }
         
         Console.Write("\nDice Results: ");
         Console.WriteLine(string.Join(" ", showResults));
         Console.WriteLine($"Number of Successes: {totalSuccesses}");
         Console.WriteLine($"Test Difficulty: {testDifficulty}");
         
         //###############################################################
         
         //FIM DA CENA
         if(totalSuccesses >= testDifficulty){
             Console.WriteLine("SUCCESS!!!\n");
             string narration2 = "You managed to sneak up on him and, as quick as a wildcat, bit his neck and drew a mouthful of blood. You slaked your Hunger once more! However, the blood loss caused the already very weak homeless to die. You satisfied your Hunger, the Beast is silent for once, but at the cost of an innocent life and a piece of your already dim Humanity.";
        
            // Escreve a mensagem letra à letra.
            foreach (char letra in narration2)
            {
                Console.Write(letra);
                Thread.Sleep(100); 
            }
         } else if (totalSuccesses >= testDifficulty && criticalSuccess > 0) {
             Console.WriteLine("CRITICAL SUCCESS!!!\n");
             string narration2 = "You move swiftly, leaving no trace! You gently bite the homeless' neck and take enough to satisfy your Hunger without causing him to lose his life from blood loss. Your Hunger is slightly sated, your Beast still cries out for more, but you emerge from this still human, with your Humanity intact.";
        
            // Escreve a mensagem letra à letra.
            foreach (char letra in narration2)
            {
                Console.Write(letra);
                Thread.Sleep(100); 
            }
         }
         else {
            Console.WriteLine("FAILURE!!!\n");
             string narration3 = "The homeless notice you creeping upon him and shouts \"ARGH! A CRAB NIPPLE!!!\", a police officer near the scene catches the scream and rush towards the alley, but you are long gone, closing the manhole to the sewers. The Beast is hungry! Rat blood will have to suffice.";
        
            // Escreve a mensagem letra à letra.
            foreach (char letra in narration3)
            {
                Console.Write(letra);
                Thread.Sleep(100); 
            } 
         }
         
         Console.WriteLine("\n\nEND GAME!");
    }     
}
