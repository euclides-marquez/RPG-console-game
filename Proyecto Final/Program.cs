//RPG el bueno hd


using System;

using System.Collections.Generic;



namespace Proyecto_Final
{
    class Program
    {
        //Parámetros del personaje
        static string CharacterName;
        static int vida, fuerza, dinero, sigilo;
        static int[] edges = { 0, 0, 0, 0 };

        static room currentPos, previosPos;


        //Objetos del generador (cuartos)
        static room safe = new room();
        static room dung2 = new room();
        static room dung3 = new room();
        static room dung4 = new room();
        static room dung5 = new room();
        static room game1 = new room();
        static room dung6 = new room();
        static room store = new room();
        static room bossR = new room();
        static room DONE = new room();

        static room[] totalD = {
                safe, dung2, dung3, dung4, dung5, dung6, game1, store, bossR};

        static room[] portal = {
                safe, dung2, dung3, dung4, dung5, dung6, store};

        static room XPRoom, XNRoom, YPRoom, YNRoom;

        static List<enemie> enemies;

        static bool attackTutorial = false, stealTutorial = false, scapeTutorial = false, portalTutorial = false;

        static bool lamp = false, key = false;

        static bool crashed = true;

        static bool map = false;

        static string[][] Coordinates = new string[17][]{

                new string[] { "x", "x","x","x","x","x","x","x","x","x","x","x","x","x","x","x","x"},        //0
                new string[] { "x", "x","x","x","x","x","x","x","x","x","x","x","x","x","x","x","x"},       //1
                new string[] {  "x", "x","x","x","x","x","x","x","x","x","x","x","x","x","x","x","x"},       //2 
                new string[] {  "x", "x","x","x","x","x","x","x","x","x","x","x","x","x","x","x","x"},       //3
                new string[] {  "x", "x","x","x","x","x","x","x","x","x","x","x","x","x","x","x","x",},       //4
                new string[] {  "x", "x","x","x","x","x","x","x","x","x","x","x","x","x","x","x","x",},       //5
                new string[] {  "x", "x","x","x","x","x","x","x","x","x","x","x","x","x","x","x","x"},       //6
                new string[] {  "x", "x","x","x","x","x","x","x","x","x","x","x","x","x","x","x","x"},       //7
                new string[] {  "x", "x","x","x","x","x","x","x","I","x","x","x","x","x","x","x","x"},       //8
                new string[] {  "x", "x","x","x","x","x","x","x","x","x","x","x","x","x","x","x","x"},       //9
                new string[] {  "x", "x","x","x","x","x","x","x","x","x","x","x","x","x","x","x","x"},       //10
                new string[] {  "x", "x","x","x","x","x","x","x","x","x","x","x","x","x","x","x","x"},       //11
                new string[] {  "x", "x","x","x","x","x","x","x","x","x","x","x","x","x","x","x","x"},       //12
                new string[] {  "x", "x","x","x","x","x","x","x","x","x","x","x","x","x","x","x","x"},       //13
                new string[] {  "x", "x","x","x","x","x","x","x","x","x","x","x","x","x","x","x","x"},       //14
                new string[] {  "x", "x","x","x","x","x","x","x","x","x","x","x","x","x","x","x","x"},       //15
                new string[] {  "x", "x","x","x","x","x","x","x","x","x","x","x","x","x","x","x","x"}       //16
                
            };

        static void Main(string[] args)
        {

            //parametros iniciales
            vida = 100;    //100
            fuerza = 4;    //4
            dinero = 0;    //0
            sigilo = 5;    //5

            //----------
            

            currentPos = safe;
            //hace el terreno
            //MapGenerator();
            UltimateMapGenerator();
            

            //hace el mapa(cartografia)
            //MapHD4K();

            Console.WriteLine("Bienvenido aventurero, ¿Cuál es tu nombre?");
            CharacterName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("El malvado Jefe Mago a distorcionado la realidad, es tu deber encontrarlo y eliminarlo, solo la leyen indica que un valiente guerrero llamado " + CharacterName + " lo podrá destruir");
            Console.WriteLine("Despiertas en una mazmorra, no hay nada, solo ves 4 posibles direcciones, encuentra el jefe y termina con su pesadilla!");
            Console.ForegroundColor = ConsoleColor.White;


            while (true)
            {



                //hace el mapa (consola)xd
                generateMap();
                displayMap(currentPos);

                
                
                Console.WriteLine("");
                Console.WriteLine("abajo, arriba, izquierda, derecha, stats");
   




                Movement();

                


            }

     
        }


        private static void Movement() {
            string action = Console.ReadLine().ToLower();
            Console.Clear();

            previosPos = currentPos;
            

            switch (action)
            {
                case "arriba":
                    if (currentPos.edges[0] == "pared")
                    {
                        Console.WriteLine("no puedes pasar por las paredes");
                    }
                    else
                    {
                        currentPos = YPRoom;
                        Coordinates[currentPos.ycordinate][currentPos.xcordinate] = "O";
                        Coordinates[previosPos.ycordinate][previosPos.xcordinate] = previosPos.type;
                       
                    }
                    loadRoom();
                    break;
                case "abajo":
                    if (currentPos.edges[1] == "pared")
                    {
                        Console.WriteLine("no puedes pasar por las paredes");
                    }
                    else
                    {
                        currentPos = YNRoom;
                        Coordinates[currentPos.ycordinate][currentPos.xcordinate] = "O";
                        Coordinates[previosPos.ycordinate][previosPos.xcordinate] = previosPos.type;
                    }
                    loadRoom();
                    break;
                case "derecha":
                    if (currentPos.edges[3] == "pared")
                    {
                        Console.WriteLine("no puedes pasar por las paredes");
                    }
                    else
                    {
                        currentPos = XPRoom;
                        Coordinates[currentPos.ycordinate][currentPos.xcordinate] = "O";
                        Coordinates[previosPos.ycordinate][previosPos.xcordinate] = previosPos.type;
                    }
                    loadRoom();
                    break;
                case "izquierda":
                    if (currentPos.edges[2] == "pared")
                    {
                        Console.WriteLine("no puedes pasar por las paredes");
                    }
                    else
                    {
                        currentPos = XNRoom;
                        Coordinates[currentPos.ycordinate][currentPos.xcordinate] = "O";
                        Coordinates[previosPos.ycordinate][previosPos.xcordinate] = previosPos.type;
                    }
                    loadRoom();
                    break;
                case "stats":
                    DisplayStats();
                        break;
                case "map":
                    showMap();
                    break;
                case "mh":
                    
                        Console.WriteLine("O - posición actual");
                        Console.WriteLine("I - Inicio");
                        Console.WriteLine("D - Dungeon");
                        Console.WriteLine("T- Tienda");
                        Console.WriteLine("B - Cuarto del jefe");
                        Console.WriteLine("A - Cueva oscura");
                        Console.WriteLine("P - Portal");

                    break;

                default:
                    Console.WriteLine("Escoje una opción válida");
                    break;

            }

            

        }

        private static void displayMap(room pos) {
            Console.WriteLine("");
            Console.WriteLine("-----------------");
            Console.WriteLine("Mapa");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("       "+ pos.edges[0]);
            Console.WriteLine(pos.edges[2] + "  -  " + pos.edges[3]);
            Console.WriteLine("       " + pos.edges[1]);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("");
            if (map)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("map - abrir el mapa  / mh - leyenda");
                Console.ForegroundColor = ConsoleColor.White;
            }
            


        }

        private static void DisplayStats() {

            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(CharacterName);
            Console.WriteLine("Vida: " + vida);
            Console.WriteLine("Fuerza: " + fuerza);
            Console.WriteLine("Sigilo: " + sigilo);
            Console.WriteLine("Dinero: " + dinero);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private static void generateMap()
        {

            string ypos = currentPos.edges[0];
            string yneg = currentPos.edges[1];
            string xpos = currentPos.edges[3];
            string xneg = currentPos.edges[2];
            

            foreach (room rooms in totalD)
            {
                if (rooms.name == ypos)
                {
                    YPRoom = rooms;

                }
            }

            foreach (room rooms in totalD)
            {
                if (rooms.name == yneg)
                {
                    YNRoom = rooms;

                }
            }

            foreach (room rooms in totalD)
            {
                if (rooms.name == xpos)
                {
                    XPRoom = rooms;

                }
            }

            foreach (room rooms in totalD)
            {
                if (rooms.name == xneg)
                {
                    XNRoom = rooms;

                }
            }



        }

        private static void loadRoom() {

            switch (currentPos.type) {
                case "I":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Has regresado al comienzo, recuerda que todavía debes de matar al Jefe y lograr restaurar la realidad");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case "D":

                    if (currentPos.cleared)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Ya has recuperado el item de este cuarto");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if (currentPos.name == "???????" && lamp == false) {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Te aventuras a una zona desconocida, todo esta oscuro, solo escuchas unos ruidos y pasos acercandose a ti, recibes daño pero como no puedes ver no te puedes defender, has muerto");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Game Over");
                        while (true) { };
                    }
                    else
                    {
                        generateDungeon();

                    }
                    


                    



                    break;
                case "P":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Has entrado a un cuarto en donde el espacio y el tiempo están combinados. Parece que hay 1, deseas entrar a uno? S/N");

                    if (portalTutorial == false) {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Si entras a un portal seras teletransportado a una ubicación del mapa desconocida en otro tiempo (los monstruos que hayas eliminado reapareceran)");
                        Console.ForegroundColor = ConsoleColor.White;
                        portalTutorial = true;
                    }

                    Random rnd = new Random();
                    string enter = Console.ReadLine().ToLower();
                    if(enter == "s")
                    {
                        room toTeleport = portal[rnd.Next(0, 7)];

                        previosPos = currentPos;
                        currentPos = toTeleport;
                        Coordinates[currentPos.ycordinate][currentPos.xcordinate] = "O";
                        Coordinates[previosPos.ycordinate][previosPos.xcordinate] = previosPos.type;
                        currentPos.cleared = false;
                        Console.WriteLine("Has sido teletransportado a: " + currentPos.name);
                        loadRoom();
                    }




                    break;
                case "T":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Bienvenido " + CharacterName + " a la tienda de reliquias del elfo Yoynun, qué deseas comprar?");
                    
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Lámpara - 10$");
                    Console.WriteLine("Llave - 30$");
                    Console.WriteLine("Posion de vida(+10) - 15$");
                    Console.WriteLine("Posion de fuerza(+10) - 15$");
                    Console.WriteLine("Stats");
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Salir");
                    Console.ForegroundColor = ConsoleColor.White;

                    bool inStore = true;

                    while (inStore)
                    {

                        string answer = Console.ReadLine().ToLower();

                        switch (answer)
                        {
                            case "lampara":
                                if (lamp == true)
                                {
                                    Console.WriteLine("Ya tienes ese item");
                                }
                                else if (dinero <= 10)
                                {
                                    Console.WriteLine("Dinero insuficiente");
                                }
                                else {
                                    Console.WriteLine("Item adquirido");
                                    lamp = true;
                                    dinero -= 10;
                                }



                                break;
                            case "salir":
                                inStore = false;
                                
                                break;
                            case "llave":
                                if (key == true)
                                {
                                    Console.WriteLine("Ya tienes ese item");
                                }
                                else if (dinero <= 30)
                                {
                                    Console.WriteLine("Dinero insuficiente");
                                }
                                else
                                {
                                    Console.WriteLine("Item adquirido");
                                    key = true;
                                    dinero -= 30;
                                }
                                break;
                            case "posion de vida":
                                if(dinero <= 16)
                                {
                                    Console.WriteLine("Dinero insuficiente");
                                } else
                                {
                                    {
                                        Console.WriteLine("Item adquirido");
                                        vida += 10;
                                        dinero -= 15;

                                    }
                                }
                                break;
                            case "posion de fuerza":
                                if (dinero <= 16)
                                {
                                    Console.WriteLine("Dinero insuficiente");
                                }
                                else
                                {
                                    {
                                        Console.WriteLine("Item adquirido");
                                        fuerza += 10;
                                        dinero -= 15;
                                    }
                                }
                                break;
                            case "stats":
                                DisplayStats();
                                break;
                            default:
                                Console.WriteLine("Ingresa una opción válida");
                                break;

                        }
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine("Dinero: " + dinero);
                        Console.ForegroundColor = ConsoleColor.White;

                    }


                    break;
                case "B":
                    if(key == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Parece que esta puerta está cerrada con llave, tratas de forzarla pero no se abre");
                        Console.ForegroundColor = ConsoleColor.White;
                        currentPos = previosPos;
                        
                    } else
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Se desbloquea la puerta y entras: ");
                        Console.WriteLine("Entras a una habitación donde el tiempo y el espacio parecen no tener sentido");
                        
                        Console.WriteLine("El gran mago Rarku esta dentro del cuarto");
                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Rarku: " + CharacterName + " te he estado esperando, lamento decirte que esta pelea ya la has perdido");
                        Console.WriteLine(CharacterName + ": te vencere sin importar qué!");

                        int bossHealth = 70, bossDamage = 15;

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("");
                        Console.WriteLine("-------");
                        Console.WriteLine("Tutotial: Rarku tiene la habilidad de manipular el tiempo, debido a la naturaleza del cuarto podrás viajar al pasado, presento o futuro; si adivinas donde esta Rarku le podras dar un golpe, de lo contrario te atacara desde un tiempo desconocido ");

                        while (bossHealth > 0)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkMagenta;
                            Console.WriteLine("Rarku: hahaha nunca sabras que ataco, podría atacarte ahora, en el futuro o incluso ya te ataque");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Escoje una linea temporal: ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Pasado");
                            Console.WriteLine("Presente");
                            Console.WriteLine("Futuro");
                            Console.ForegroundColor = ConsoleColor.White;
                            Random rnd2 = new Random();

                            string combat = Console.ReadLine().ToLower();
                            Console.Clear();
                            int temporalLine = rnd2.Next(1, 4);

                            switch (combat) {

                                case "pasado":
                                    if (temporalLine == 1) {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("Has logrado encontrar a Rarku");
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Rarku recibe un daño de " + fuerza);
                                        bossHealth -= fuerza;
                                        Console.WriteLine("Vida restante: " + bossHealth);
                                    } else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("No encontraste a Rarku, pasa un tiempo y sientes como recibes daño, no sabes si el daño ya lo sentias, lo acabas de sentir, o piensas que lo sientes");
                                        vida -= bossDamage;
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Tu vida a dismuniodo a: " + vida);
                                    }
                                    break;
                                case "presente":
                                    if (temporalLine == 2)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("Has logrado encontrar a Rarku");
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Rarku recibe un daño de " + fuerza);
                                        bossHealth -= fuerza;
                                        Console.WriteLine("Vida restante: " + bossHealth);
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("No encontraste a Rarku, pasa un tiempo y sientes como recibes daño, no sabes si el daño ya lo sentias, lo acabas de sentir, o piensas que lo sientes");
                                        vida -= bossDamage;
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Tu vida a dismuniodo a: " + vida);
                                    }
                                    break;
                                case "futuro":
                                    if (temporalLine == 3)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("Has logrado encontrar a Rarku");
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Rarku recibe un daño de " + fuerza);
                                        bossHealth -= fuerza;
                                        Console.WriteLine("Vida restante: " + bossHealth);
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.WriteLine("No encontraste a Rarku, pasa un tiempo y sientes como recibes daño, no sabes si el daño ya lo sentias, lo acabas de sentir, o piensas que lo sientes");
                                        vida -= bossDamage;
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.WriteLine("Tu vida a dismuniodo a: " + vida);
                                    }
                                    break;
                                case "stats":
                                    DisplayStats();
                                    break;
                                default:
                                    Console.WriteLine("Escoje una opción válida");
                                    break;

                            }

                            if(vida <= 0)
                            {
                                Console.ForegroundColor = ConsoleColor.Blue;
                                Console.WriteLine("Tu vida pasa frente a tus ojos, por fin logras ver todas las veces que Rarku te ataco desde diferentes lineas temporales, era verdad cuando llegaste ya habias perdido");
                                Console.WriteLine("Rarku termina de distorcionar la realidad de tu mundo sin que nadie lo detenga solo para cambiar de dimensión y hacerlo de nuevo, en otro mundo.");
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Game Over");
                                while (true) { };
                            }







                        }

                        Console.ForegroundColor = ConsoleColor.DarkMagenta;
                        Console.WriteLine("Rarku: No puede ser, yo no puedo ser vencido, yo controlo el tiempo y el espacio, aaaaaaaaaaaah");

                        endGame();

                    }

                    break;

            }

        
        }


        private static void endGame()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Has derrotado al hechisero, la realidad regresa pronto a la normalidad, has salvado el mundo!");
            Console.WriteLine("Fin del juego");
            while(true) { };
        }


        private static void generateDungeon() {

            //generar enemigos, generar item
            string[] enemigos = { "Goglin", "Troll", "Araña gigante", "Zombie" };
            Random rnd = new Random();
            int numberOfEnemies = rnd.Next(1, 3);
            enemies = new List<enemie>();

            item[] items =
            {
                new item() {name = "Espada de Kok", atributo = "fuerza", modificador = 5},
                new item() {name = "Daga de Lilith", atributo = "fuerza", modificador = 3},
                new item() {name = "Peto de Erk", atributo = "vida", modificador = 20},
                new item() {name = "Escudo de Warduk", atributo = "vida", modificador = 10},
                new item() {name = "Sandalias de ninja", atributo = "sigilo", modificador = 5},
                new item() {name = "Máscara negra", atributo = "sigilo", modificador = 3},

            };

            item DItem = items[rnd.Next(0, 6)];


            for (int i = 0; i <= numberOfEnemies; i++) {

                enemies.Add(new enemie() { name = enemigos[rnd.Next(0, 4)], health = rnd.Next(1,20), damage = rnd.Next(1,8) });
            }

            // narrativa
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Valiente aventurero " + CharacterName + " has entrado a " + currentPos.name + " al entrar te has encontrado con lo siguiente: ");
            

            foreach (enemie p in enemies) {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(p.name);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Vida: " + p.health);
                Console.WriteLine("Daño: " + p.damage);

            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Item protejido: " + DItem.name);

            Console.ForegroundColor = ConsoleColor.White;

            //combate
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Los enemigos te han bloqueado las salidas, escoje que hacer: ");


            
            
            bool traped = true, itemStatus = true;
            while (traped)
            {
  
                if (enemies.Count == 0) {
                    traped = false;
                    Console.WriteLine("Item Recuperado");
                    AddItem(DItem);
                    itemStatus = false;
                    currentPos.cleared = true;

                    if(currentPos == dung6)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Te aventuras a la cueva oscura, dentro del lugar logras encontrar un mapa de todo el calabozo, escribe -map- en la navegación para abrir");
                        Console.ForegroundColor = ConsoleColor.White;
                        map = true;
                    }


                    continue;
                }



                int stealLevel = rnd.Next(1, 21);
      
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1- Atacar");
                Console.WriteLine("2- Robar Item");
                Console.WriteLine("3- Escapar");
                Console.WriteLine("4- Stats");
                Console.ForegroundColor = ConsoleColor.White;
                string action = Console.ReadLine().ToLower();

                switch (action)
                {
                    case "atacar":
                        if (attackTutorial == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Solo podras atacar a un enemigo a la vez, terminando el ataque recibiras daño de todos los enemigos");
                            Console.WriteLine("Deseas continuar la acción? S/N");
                            Console.ForegroundColor = ConsoleColor.White;
                            string confirm = Console.ReadLine().ToLower();
                            if (confirm == "n")
                            {
                                continue;
                            }
                            attackTutorial = true;
                        }


                        attack(enemies);
                        takeDamage(enemies);

                        foreach (enemie p in enemies)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine(p.name);
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("Vida: " + p.health);
                            Console.WriteLine("Daño: " + p.damage);

                        }

                        break;
                    case "robar item":




                        if (stealTutorial == false) {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Podras intentar robar el item sin que los monstruos se den cuenta, esto basado en tu puntuación de Sigilo, si fallas recibiras daño de todos los monstruos");
                            Console.WriteLine("Deseas continuar la acción? S/N");
                            Console.ForegroundColor = ConsoleColor.White;
                            string confirm = Console.ReadLine().ToLower();
                            if(confirm == "n")
                            {
                                continue;
                            }
                            stealTutorial = true;
                        }

                        if (!itemStatus) {
                            Console.WriteLine("El item ya ha sido robado, intenta otra acción");
                            continue;
                        }


                        if (sigilo >= stealLevel)
                        {
                            Console.WriteLine("Item Robado");
                            AddItem(DItem);
                            itemStatus = false;
                        }
                        else {
                            Console.WriteLine("Has sido descubierto y los monstruos te atacan");
                            takeDamage(enemies);
                        }

                        break;
                    case "escapar":

                        if (scapeTutorial == false)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Podras intentar escapar sin que los monstruos se den cuenta, esto basado en tu puntuación de Sigilo, si fallas recibiras daño de todos los monstruos");
                            Console.WriteLine("Deseas continuar la acción? S/N");
                            Console.ForegroundColor = ConsoleColor.White;
                            string confirm = Console.ReadLine().ToLower();
                            if (confirm == "n")
                            {
                                continue;
                            }
                            scapeTutorial = true;
                        }

                        if (sigilo >= stealLevel)
                        {
                            Console.WriteLine("Has logrado escapar!, escoje hacia donde quieres ir");
                            traped = false;

                        }
                        else {
                            Console.WriteLine("Has sido descubierto y los monstruos te atacan");
                            takeDamage(enemies);
                        }



                        break;
                    case "stats":
                        DisplayStats();
                        break;
                    default:
                        Console.WriteLine("Escoje una opción válida");
                        break;


                }



            }



        }



        private static void attack(List<enemie> enemiesC) {

            Random rnd = new Random();
            int critical = rnd.Next(1, 5);
            int damage = fuerza;


            Console.WriteLine("A qué enemigo deseas atacar? (escribe el número)");
            int index = 0;
            foreach(enemie combatEnemies in enemies)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                index++;
                Console.WriteLine(index + "- " + combatEnemies.name);
                combatEnemies.indexNumer = index;
                Console.ForegroundColor = ConsoleColor.White;
            }

            int choosenEnemie = Convert.ToInt32(Console.ReadLine());

            enemie toRemove = enemies[0];

            int index2 = 0;
            foreach (enemie toAttack in enemies) {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                if (toAttack.indexNumer == choosenEnemie) {
                    toRemove = toAttack;
                    toRemove.indexNumer = index2;
                    if (critical == 1) {
                        toAttack.health -= (damage*2);
                        Console.WriteLine(toAttack.name + " a recibido un golpe crítico de " + damage*2);
                    } else {
                        toAttack.health -= damage;
                        Console.WriteLine(toAttack.name + " a recibido un golpe de " + damage);

                    }

                    
                    Console.ForegroundColor = ConsoleColor.White;

                }
                index2++;
            }
            int loot = rnd.Next(5, 11);
            if (toRemove.health <= 0)
                
            {
                Console.WriteLine("El enemigo ha muerto");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Recibes " + loot + " de oro");
                dinero += loot;
                enemies.RemoveAt(toRemove.indexNumer);
                Console.ForegroundColor = ConsoleColor.White;

            }



        }



        private static void AddItem(item itemToAdd) {
            int previous;
            switch (itemToAdd.atributo) {
                case "fuerza":
                    previous = fuerza;
                    fuerza += itemToAdd.modificador;
                    Console.WriteLine("Fuerza incrementa de " + previous + " a " + fuerza);
                    break;
                case "vida":
                    previous = vida;
                    vida += itemToAdd.modificador;
                    Console.WriteLine("Vida incrementa de " + previous + " a " + vida);
                    break;
                case "sigilo":
                    previous = sigilo;
                    sigilo += itemToAdd.modificador;
                    Console.WriteLine("Sigilo incrementa de " + previous + " a " + sigilo);
                    break;


            }
        
        }


        private static void takeDamage(List<enemie> enemies) {
            foreach (enemie en in enemies) {
                Random rnd = new Random();
                int dodge = rnd.Next(1, 4);

                Console.ForegroundColor = ConsoleColor.DarkRed;
                if (dodge == 1)
                {

                    Console.WriteLine(en.name + " te ha atacado, haciendo un daño de: " + en.damage);
                    Console.WriteLine("Logras esquivar el ataque");
                    Console.WriteLine("Vida restante: " + vida);
                }
                else { 
                    vida -= en.damage;
                    Console.WriteLine(en.name + " te ha atacado, haciendo un daño de: " + en.damage);
                    
                    Console.WriteLine("Vida restante: " + vida);
                }

                
               
                Console.ForegroundColor = ConsoleColor.White;

                if (vida <= 0) {
                    Console.WriteLine("Game Over");
                    while (true) { };
                }

            }
        }



        // <>
        private static void MapGenerator() {

            
            int dungeons = 5, juegos = 2, tienda = 1, boss = 1;
            int total = dungeons + juegos + tienda + boss;

            Random rnd = new Random();
            //crear un cuarto por zona

            


            

            safe.name = "Inicio";
            dung2.name = "Cueva del Olvido";
            dung3.name = "Grieta de la desesperanza";
            dung4.name = "Mazmorra de Zodar";
            dung5.name = "Villa de Alkheim";
            game1.name = "Cuarto del portal";
            dung6.name = "???????";
            store.name = "Tienda del buen elfo";
            bossR.name = "Sala del jefe";

            safe.type = "I";
            dung2.type = "D";
            dung3.type = "D";
            dung4.type = "D";
            dung5.type = "D";
            dung6.type = "D";
            game1.type = "G";
            store.type = "T";
            bossR.type = "B";

            int count = 0;
            int index = 0;


            //while (true) {
            
                foreach (room currentRoom in totalD) {



                    //if (total != 0) {


                        foreach (string edge in currentRoom.edges) {
                            if (edge == "pared") {
                                count += 1;
                            }
                        }

              
                        while (count > 2 && total != 0) {
                            int chooser = rnd.Next(0, 9);
                            int edge = rnd.Next(0, 4);

                            //si el cuarto escojido es el mismo que se pone se escoje otro
                            if (totalD[chooser] == totalD[index]) {
                                continue;
                            }

                            //si el cuarto ya se encuentra dentro de las esquinas del cuarto a poner se escoje otro
                            foreach (string duplicate in currentRoom.edges) {
                                if (duplicate == totalD[chooser].name) {
                                    continue;
                                }

                            }

                            


                            if (totalD[chooser].edges[edge] == "pared" && currentRoom.edges[GetOpposite(edge)] == "pared") {



                                totalD[chooser].edges[edge] = currentRoom.name;
                                currentRoom.edges[GetOpposite(edge)] = totalD[chooser].name;
                                count -= 1;
                                total -= 1;
                            } else {
                                continue;


                            }

                        }
                    //}

                    index += 1;
                    count = 0;
                }
            //string checkIfFill = "";
            //bool fillFlag = false;
            //foreach (room currentRoom in totalD) {

            //        foreach (string cord in currentRoom.edges)
            //        {
            //            checkIfFill += cord;

            //        }
            //        Console.WriteLine(checkIfFill);
            //        if (checkIfFill == "gggg") {
            //            fillFlag = true;
            //            break;
            //        }
            //        checkIfFill = "";
            //    }

            //    Console.WriteLine("patas de ashley");

            //    if (fillFlag == true)
            //    {
            //        foreach (room currentRoom in totalD)
            //        {

            //            for (int i = 0; i < 4; i++) {
            //                currentRoom.edges[i] = "g";
            //            }
            //        }


            //        continue;
            //    }
            //    else {
            //        break;
            //    }

            //}






            //debuggin map
            //foreach (room currentroom in totalD)
            //{
            //    Console.WriteLine("------------" + currentroom.name + "--------------");
            //    foreach (string edge in currentroom.edges)
            //    {
            //        Console.WriteLine(edge);
            //    }

            //}









        }


        private static int GetOpposite(int edge) {

            switch (edge) {
                case 0:
                    return 1;
                case 1:
                    return 0;
                case 2:
                    return 3;
                case 3:
                    return 2;
                default:
                    return 100;

            }
        
        }

        private static void MapHD4K()
        {
            Console.WriteLine();

            

            //Initial coordinate
            //Console.WriteLine(Coordinates[8][8]);
            int totalRooms = 9;
            safe.xcordinate = 8;
            safe.ycordinate = 8;
            bool done = false;

            int x, y, edge;
            int loopCount = 0;

            while (!done)
            {

                foreach (room toMap in totalD)
            {
                    if (toMap.positioned == true)
                    {
                        continue;
                    }
                    if(toMap.xcordinate == 0 || toMap.ycordinate == 0)
                    {
                        continue;
                    }

                    Console.WriteLine(toMap.name);


                    //paso el filtro
                    toMap.positioned = true;
                    totalRooms -= 1;

                    //se loopea 4 veces
                    foreach (string edges in toMap.edges)
                {





                        if (Coordinates[toMap.ycordinate - 1][toMap.xcordinate] == "P" || Coordinates[toMap.ycordinate - 1][toMap.xcordinate] == "R" && Coordinates[toMap.ycordinate - 1][toMap.xcordinate] != "I")
                        {
                            Coordinates[toMap.ycordinate - 1][toMap.xcordinate] = "O";

                        }

                        if (Coordinates[toMap.ycordinate + 1][toMap.xcordinate] == "P" || Coordinates[toMap.ycordinate + 1][toMap.xcordinate] == "R" && Coordinates[toMap.ycordinate - 1][toMap.xcordinate] != "I")
                        {
                            Coordinates[toMap.ycordinate + 1][toMap.xcordinate] = "O";

                        }

                        if (Coordinates[toMap.ycordinate][toMap.xcordinate - 1] == "P" || Coordinates[toMap.ycordinate - 1][toMap.xcordinate] == "R" && Coordinates[toMap.ycordinate - 1][toMap.xcordinate] != "I")
                        {
                            Coordinates[toMap.ycordinate][toMap.xcordinate - 1] = "O";

                        }

                        if (Coordinates[toMap.ycordinate][toMap.xcordinate + 1] == "P" || Coordinates[toMap.ycordinate - 1][toMap.xcordinate] == "R" && Coordinates[toMap.ycordinate - 1][toMap.xcordinate] != "I")
                        {
                            Coordinates[toMap.ycordinate][toMap.xcordinate + 1] = "O";

                        }

                        //abajo

                        if (Coordinates[toMap.ycordinate - 1][toMap.xcordinate] == "I" || Coordinates[toMap.ycordinate - 1][toMap.xcordinate] == "O")
                        {
                            y = toMap.ycordinate - 1;
                            x = toMap.xcordinate;
                            edge = 0;
                            UpdateCords(toMap, x, y, edge);

                            y = 0;
                            x = 0;
                            edge = 0;
                            continue;
                        }


                        if (toMap.edges[0] == "pared")
                        {
                            Coordinates[toMap.ycordinate - 1][toMap.xcordinate] = "P";
                            
                            y = toMap.ycordinate - 1;
                            x = toMap.xcordinate;
                            edge = 0;
                            UpdateCords(toMap, x, y, edge);
                            
                            y = 0;
                            x = 0;
                            edge = 0;
                        }
                        else if (toMap.edges[0] == "Inicio")
                        {
                            y = toMap.ycordinate - 1;
                            x = toMap.xcordinate;
                            edge = 0;
                            UpdateCords(toMap, x, y, edge);

                            y = 0;
                            x = 0;
                            edge = 0;
                            continue;

                        }
                        else 
                        {

                            Coordinates[toMap.ycordinate - 1][toMap.xcordinate] = "R";
                            y = toMap.ycordinate - 1;
                            x = toMap.xcordinate;
                            edge = 0;
                            UpdateCords(toMap, x, y, edge);
                            
                            y = 0;
                            x = 0;
                            edge = 0;
                        }
                        //arriba
                        if (Coordinates[toMap.ycordinate + 1][toMap.xcordinate] == "I" )
                        {
                            y = toMap.ycordinate - 1;
                            x = toMap.xcordinate;
                            edge = 1;
                            UpdateCords(toMap, x, y, edge);

                            y = 0;
                            x = 0;
                            edge = 0;
                            continue;
                        }
                        if (toMap.edges[1] == "pared")
                        {
                            Coordinates[toMap.ycordinate + 1][toMap.xcordinate] = "P";
                            y = toMap.ycordinate + 1;
                            x = toMap.xcordinate;
                            edge = 1;
                            UpdateCords(toMap, x, y, edge);

                            y = 0;
                            x = 0;
                            edge = 0;
                        }
                        else if (toMap.edges[1] == "Inicio")
                        {
                            y = toMap.ycordinate + 1;
                            x = toMap.xcordinate;
                            edge = 1;
                            UpdateCords(toMap, x, y, edge);

                            y = 0;
                            x = 0;
                            edge = 0;
                            continue;
                        }
                        else 
                        {
                            Coordinates[toMap.ycordinate + 1][toMap.xcordinate] = "R";
                            y = toMap.ycordinate + 1;
                            x = toMap.xcordinate;
                            edge = 1;
                            UpdateCords(toMap, x, y, edge);

                            y = 0;
                            x = 0;
                            edge = 0;
                        }
                        //Izquierda
                        if (Coordinates[toMap.ycordinate][toMap.xcordinate - 1] == "I" )
                        {
                            y = toMap.ycordinate - 1;
                            x = toMap.xcordinate;
                            edge = 2;
                            UpdateCords(toMap, x, y, edge);

                            y = 0;
                            x = 0;
                            edge = 0;
                            continue;
                        }
                        if (toMap.edges[2] == "pared")
                        {
                            Coordinates[toMap.ycordinate][toMap.xcordinate - 1] = "P";
                            y = toMap.ycordinate;
                            x = toMap.xcordinate - 1;
                            edge = 2;
                            UpdateCords(toMap, x, y, edge);

                            y = 0;
                            x = 0;
                            edge = 0;
                        }
                        else if (toMap.edges[2] == "Inicio")
                        {
                            y = toMap.ycordinate;
                            x = toMap.xcordinate - 1;
                            edge = 2;
                            UpdateCords(toMap, x, y, edge);

                            y = 0;
                            x = 0;
                            edge = 0;
                            continue;
                        }
                        else 
                        {
                            Coordinates[toMap.ycordinate][toMap.xcordinate - 1] = "R";
                            y = toMap.ycordinate;
                            x = toMap.xcordinate - 1;
                            edge = 2;
                            UpdateCords(toMap, x, y, edge);

                            y = 0;
                            x = 0;
                            edge = 0;
                        }
                        //Derecha
                        if (Coordinates[toMap.ycordinate][toMap.xcordinate + 1] == "I")
                        {
                            y = toMap.ycordinate - 1;
                            x = toMap.xcordinate;
                            edge = 3;
                            UpdateCords(toMap, x, y, edge);

                            y = 0;
                            x = 0;
                            edge = 0;
                            continue;
                        }
                        if (toMap.edges[3] == "pared")
                        {

                            Coordinates[toMap.ycordinate][toMap.xcordinate + 1] = "P";
                            y = toMap.ycordinate;
                            x = toMap.xcordinate + 1;
                            edge = 3;
                            UpdateCords(toMap, x, y, edge);

                            y = 0;
                            x = 0;
                            edge = 0;
                        }
                        else if (toMap.edges[3] == "Inicio")
                        {
                            y = toMap.ycordinate;
                            x = toMap.xcordinate + 1;
                            edge = 3;
                            UpdateCords(toMap, x, y, edge);

                            y = 0;
                            x = 0;
                            edge = 0;
                            continue;
                        }
                        else 
                        {
                            Coordinates[toMap.ycordinate][toMap.xcordinate + 1] = "R";
                            y = toMap.ycordinate;
                            x = toMap.xcordinate + 1;
                            edge = 3;
                            UpdateCords(toMap, x, y, edge);

                            y = 0;
                            x = 0;
                            edge = 0;
                        }
                    }
                }

                if (
                    safe.positioned == true &&
                    dung2.positioned == true &&
                    dung3.positioned == true &&
                    dung4.positioned == true &&
                    dung5.positioned == true &&
                    dung6.positioned == true &&
                    game1.positioned == true &&
                    store.positioned == true &&
                    bossR.positioned == true
                    )
                {
                    done = true;
                }


                loopCount += 1;

                if(loopCount > 500)
                {
                    
                    crashed = true;
                    Console.WriteLine("Crashed");
                    ClearMap();
                    ClearRoomsCords();
                    break;
                } else
                {
                    crashed = false;
                }

            }

        

            


        }

        private static void showMap()
        {
            string rowD = "";
            for (int row = 0; row < 17; row++)
            {
                for (int colum = 0; colum < 17; colum++)
                {
                    
                    rowD += Coordinates[row][colum];

                }
                Console.WriteLine(rowD);
                rowD = "";
            }
        }


        private static void ClearMap()
        {
            
            for (int row = 0; row < 17; row++)
            {
                for (int colum = 0; colum < 17; colum++)
                {

                    Coordinates[row][colum] = "x";

                }
                
            }
        }

        private static void ClearRoomsCords()
        {
            foreach (room room in totalD)
            {
                room.xcordinate = 0;
                room.ycordinate = 0;
                room.positioned = false;
               
            }
        }

        static void UpdateCords (room roomFromBuild,int x, int y, int edge)
        {
            string roomToUpdate = roomFromBuild.edges[edge];

            foreach(room room in totalD)
            {
                if(room.name == roomToUpdate)
                {
                    room.xcordinate = x;
                    room.ycordinate = y;
                }
            }



        }


        private static void UltimateMapGenerator()
        {

            Random rnd = new Random();

            safe.name = "Inicio";
            dung2.name = "Cueva del Olvido";
            dung3.name = "Grieta de la desesperanza";
            dung4.name = "Mazmorra de Zodar";
            dung5.name = "Villa de Alkheim";
            game1.name = "Cuarto del portal";
            dung6.name = "???????";
            store.name = "Tienda del buen elfo";
            bossR.name = "Sala del jefe";

            safe.type = "I";
            dung2.type = "D";
            dung3.type = "D";
            dung4.type = "D";
            dung5.type = "D";
            dung6.type = "D";
            game1.type = "P";
            store.type = "T";
            bossR.type = "B";

            safe.xcordinate = 8;
            safe.ycordinate = 8;
            bool edgeChooser = false, edgeEmpty = false;
            int edge = 0, chooser = 0;
            room ChosenRoom = new room();
            safe.positioned = true;
            int x, y;

            for (int rooms = 0; rooms <= 1; rooms++)
            {
                edge = 0;
                chooser = 0;
                edgeChooser = false;
                edgeEmpty = false;
                //revisar si el edge esta vacio

                while (!edgeEmpty)
                {
                    edge = rnd.Next(0, 4);
                    if (safe.edges[edge] == "pared")
                    {
                        edgeEmpty = true;
                    }
                }


                //revisar si el cuarto no esta repetido

                while (!edgeChooser)
                {
                    chooser = rnd.Next(0, 9);


                    //revisar si el escojido es el mismo que el objeto
                    if (totalD[chooser] == safe)
                    {
                        continue;
                    }

                    if(totalD[chooser] == bossR || totalD[chooser] == dung6)
                    {
                        continue;
                    }



                    //revisar si el escojido ya estaba en la lista
                    edgeChooser = true;
                    foreach (string edgeToCheck in safe.edges)
                    {
                        if (totalD[chooser].name == edgeToCheck)
                        {
                            edgeChooser = false;
                        }
                    }



                }



                //actualizar el edge del objeto "main" y del objeto seleccionado
                safe.edges[edge] = totalD[chooser].name;
                totalD[chooser].edges[GetOpposite(edge)] = safe.name;


                ChosenRoom = totalD[chooser];
                totalD[chooser].positioned = true;

                //actualizar el grid
                
                switch (edge)
                {
                    case 0:
                        x = safe.xcordinate;
                        y = safe.ycordinate - 1;
                        Coordinates[y][x] = totalD[chooser].type;

                        totalD[chooser].xcordinate = x;
                        totalD[chooser].ycordinate = y;


                        break;
                    case 1:
                        x = safe.xcordinate;
                        y = safe.ycordinate + 1;
                        Coordinates[y][x] = totalD[chooser].type;

                        totalD[chooser].xcordinate = x;
                        totalD[chooser].ycordinate = y;
                        break;
                    case 2:
                        x = safe.xcordinate - 1;
                        y = safe.ycordinate;
                        Coordinates[y][x] = totalD[chooser].type;

                        totalD[chooser].xcordinate = x;
                        totalD[chooser].ycordinate = y;
                        break;
                    case 3:
                        x = safe.xcordinate + 1;
                        y = safe.ycordinate;
                        Coordinates[y][x] = totalD[chooser].type;

                        totalD[chooser].xcordinate = x;
                        totalD[chooser].ycordinate = y;
                        break;
                }



            }

            room backup = new room();
            bool trapPosed = false;
            //generar los demás cuartos
            for (int i = 0; i <= 2; i++)
            {

                for (int rooms = 0; rooms <= 1; rooms++)
                {
                    edge = 0;
                    chooser = 0;
                    edgeChooser = false;
                    edgeEmpty = false;
                    

                    int xE = 0, yE = 0;
                    //revisar si el edge esta vacio

                    while (!edgeEmpty)
                    {
                        edge = rnd.Next(0, 4);
                        if (ChosenRoom.edges[edge] == "pared")
                        {
                            //revisar que no se superpongan
                            xE = 0;
                            yE = 0;
                            switch (edge)
                            {
                                case 0:
                                    xE = ChosenRoom.xcordinate;
                                    yE = ChosenRoom.ycordinate - 1;

                                    if (Coordinates[yE][xE] != "x")
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        edgeEmpty = true;
                                    }

                                    break;
                                case 1:
                                    xE = ChosenRoom.xcordinate;
                                    yE = ChosenRoom.ycordinate + 1;
                                    if (Coordinates[yE][xE] != "x")
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        edgeEmpty = true;
                                    }
                                    break;
                                case 2:
                                    xE = ChosenRoom.xcordinate - 1;
                                    yE = ChosenRoom.ycordinate;
                                    if (Coordinates[yE][xE] != "x")
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        edgeEmpty = true;
                                    }
                                    break;
                                case 3:
                                    xE = ChosenRoom.xcordinate + 1;
                                    yE = ChosenRoom.ycordinate;
                                    if (Coordinates[yE][xE] != "x")
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        edgeEmpty = true;
                                    }
                                    break;
                            }






                        }
                    }


                    //revisar si el cuarto no esta repetido

                    if(i == 1 && !trapPosed)
                    {
                        edgeChooser = true;
                        chooser = 5;
                        trapPosed = true;
                    }



                    while (!edgeChooser)
                    {
                        chooser = rnd.Next(0, 9);


                        if(totalD[chooser] == dung6)
                        {
                            continue;
                        }


                        //revisar si el escojido es el mismo que el objeto
                        if (totalD[chooser] == ChosenRoom)
                        {
                            continue;
                        }


                        // revisar si el escojido ya fue puesto
                        if (totalD[chooser].positioned == true)
                        {
                            continue;
                        }


                        //revisar si el escojido ya estaba en la lista
                        edgeChooser = true;
                        foreach (string edgeToCheck in ChosenRoom.edges)
                        {
                            if (totalD[chooser].name == edgeToCheck)
                            {
                                edgeChooser = false;
                            }
                        }






                    }



                    //actualizar el edge del objeto "main" y del objeto seleccionado
                    ChosenRoom.edges[edge] = totalD[chooser].name;
                    totalD[chooser].edges[GetOpposite(edge)] = ChosenRoom.name;
                    totalD[chooser].positioned = true;


                    //actualizar el grid
                 
                    switch (edge)
                    {
                        case 0:
                            x = ChosenRoom.xcordinate;
                            y = ChosenRoom.ycordinate - 1;
                            Coordinates[y][x] = totalD[chooser].type;

                            totalD[chooser].xcordinate = x;
                            totalD[chooser].ycordinate = y;


                            break;
                        case 1:
                            x = ChosenRoom.xcordinate;
                            y = ChosenRoom.ycordinate + 1;
                            Coordinates[y][x] = totalD[chooser].type;

                            totalD[chooser].xcordinate = x;
                            totalD[chooser].ycordinate = y;
                            break;
                        case 2:
                            x = ChosenRoom.xcordinate - 1;
                            y = ChosenRoom.ycordinate;
                            Coordinates[y][x] = totalD[chooser].type;

                            totalD[chooser].xcordinate = x;
                            totalD[chooser].ycordinate = y;
                            break;
                        case 3:
                            x = ChosenRoom.xcordinate + 1;
                            y = ChosenRoom.ycordinate;
                            Coordinates[y][x] = totalD[chooser].type;

                            totalD[chooser].xcordinate = x;
                            totalD[chooser].ycordinate = y;
                            break;
                    }

                    

                    if (rooms == 1)
                    {
                        ChosenRoom = totalD[chooser];
                    } else
                    {
                        backup = totalD[chooser];  //????
                    }

                    if(ChosenRoom == bossR && rooms == 1)
                    {
                        ChosenRoom = backup;
                    }

                    if (ChosenRoom == dung6 && rooms == 1)
                    {
                        ChosenRoom = backup;
                    }




                }




            }


            //parchear el mapa


            //foreach (room finalRoom in totalD)
            //{

            //    Console.WriteLine("patas de ashley");

            //    x = finalRoom.xcordinate;
            //    y = finalRoom.ycordinate;

            //    Console.WriteLine(x + "" + y);

            //    if (Coordinates[x][y - 1] != "x")
            //    {
            //        Console.WriteLine(x + "" + y);
            //        x = finalRoom.xcordinate;
            //        y = finalRoom.ycordinate - 1;
            //        Console.WriteLine(x + "" + y);

            //        finalRoom.edges[0] = GetRoomByCoord(x, y).name;
            //        Console.WriteLine(x + "" + y);

            //    }

            //    x = finalRoom.xcordinate;
            //    y = finalRoom.ycordinate;

            //    if (Coordinates[x][y + 1] != "x")
            //    {
            //        x = finalRoom.xcordinate;
            //        y = finalRoom.ycordinate + 1;

            //        finalRoom.edges[1] = GetRoomByCoord(x, y).name;

            //    }

            //    x = finalRoom.xcordinate;
            //    y = finalRoom.ycordinate;

            //    if (Coordinates[x - 1][y] != "x")
            //    {
            //        x = finalRoom.xcordinate - 1;
            //        y = finalRoom.ycordinate;

            //        finalRoom.edges[2] = GetRoomByCoord(x, y).name;

            //    }

            //    x = finalRoom.xcordinate;
            //    y = finalRoom.ycordinate;

            //    if (Coordinates[x + 1][y] != "x")
            //    {
            //        x = finalRoom.xcordinate + 1;
            //        y = finalRoom.ycordinate;

            //        finalRoom.edges[3] = GetRoomByCoord(x, y).name;

            //    }



            //}


            int count = 0;
            foreach (string edgeF in dung6.edges)
            {
                if (edgeF == "pared")
                {
                    count++;
                }
            }
            
            if(count != 3)
            {
                Console.WriteLine("MAP GEN CRASHED! RESTART GAME");
            }


        }


        static room GetRoomByCoord(int x, int y)
        {
            room toPass = new room();
            foreach(room room in totalD)
            {
                if(room.xcordinate == x && room.ycordinate == y)
                {
                    toPass = room;
                } 
            }
         
                return toPass;
        }


    }




    public class room {
                                //Abajo, Arriba, Izquierda, Derecha
        public string[] edges = { "pared", "pared", "pared", "pared" };
        public string name;
        public string type;
        public bool cleared = false;
        public int ycordinate = 0, xcordinate = 0;
        public bool positioned = false;
    
    }


    public class enemie {
        public string name;
        public int health, damage, indexNumer;

        public enemie()
        {
        }

        public enemie(string nameC, int healthC, int damageC) {
            name = nameC;
            health = healthC;
            damage = damageC;
        }
    }


    public class item
    {
        public string name;
        public string atributo;
        public int modificador;

        public item() { 
        }

        public item(string nameC, string AC, int dC)
        {
            name = nameC;
            atributo = AC;
            modificador = dC;
        }

    }


    



}



