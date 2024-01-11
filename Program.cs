using System;
using System.Linq; // Linq 등판 ,  OrderBy 메소드 + 람다식 사용
using TextRPG3;


namespace TextRPG3
{
    // A. 팀 과제 개요
    // 캐릭터가 던전 입장 -> 전투
    // 여러 몬스터들과 상호 작용
    // 캐릭터, 몬스터는 객체나 구조체를 활용 ( 이름, 능력, 설명 등 )
    // 캐릭터와 몬스터의 데이터를 변경했을때 어떻게 유지되는가에 대한 고민

    // 2. 필수 요구 사항

    // 게임 시작 화면
    // 상태 보기
    // 전투 시작



    // 3. 선택 사항
    // 캐릭터 생성 / 직업 선택 
    // 스킬, 치명타, 회피
    // 레벨 업
    // 보상 추가
    // 콘솔 꾸미기
    // 몬스터 종류 추가
    // 회복 아이템 ( 회복량, 체력상한, 보유량 등 )
    // 스테이지 추가
    // 게임 저장하기

    // 4. 나만의 기능을 만들어 보기, 개인 개선     대부분 짬 시킬 기능..
    // 직업 별 다른 기본 스탯
    // 추가 스탯, 스피드 (회피율에 영향을 줌)
    // 직업 별 전용 무기, 방어구
    // 무기, 방어구의 내구도 감소 및 수리  ->  (대장간) 골드 소모
    // 무기, 방어구의 확률적 강화 기능 -> (대장간) 골드 소모
    // 보스 몬스터 추가, 몬스터 치명타 or 스킬, 전투 중 포션
    // 무기, 방어구 외에 악세서리 추가


    //    기본 구현 구성

    // 클래스 설정 ( 캐릭터, 몬스터, 아이템 )

    //    스타트 화면 (한 번만 표시) -> 
    // 0. 캐릭터 생성, 이름 및 직업 선택
    // 1. 시작 화면
    // 2. 상태 보기 
    // 3. 인벤토리 - 장착, 해제 등
    // 4. 상점 - 일단 pass
    // 5. 던전 입장 -  몬스터와 전투 시작 ( 추후 던전 메뉴로 활용, 난이도 등)
    // 6. 휴식
    // 7. 게임 저장 / 불러오기
    // 8. 게임 종료



    //public enum JobType // 직업 enum, 일단 원래 배운 방식대로 구현 할 거라 미사용
    //{
    //    Warrior,
    //    Mage,
    //    Theif,
    //    Programmer,
    //}

    public class Character // 플레이어 캐릭터 클래스
    {
        public string Name { get; } // 이름 및 직업은 생성 시에만 설정 할 거고, '게임 중'에는 바뀌지 않기 때문에 get;만 설정
        public string Job { get; }
        public int Level { get; set; }
        //public int Exp { get; set; } // 레벨업을 위한 경험치
        public int Atk { get; set; }
        public int Def { get; set; }

        //public int Speed { get; set; } // Atk, Def 처럼 레벨업에 따라 변하며, 아이템 장착 유무 및 회피 기능에 연관, 미구현
        public int Hp { get; set; }
        // public int Mp { get; set; } 마나
        public int Gold { get; set; }


        public Character(string name, string job, int level, int atk, int def, int hp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            //Exp = exp;
            Atk = atk;
            Def = def;
            //Speed = speed; 
            Hp = hp;
            // Mp = mp;
            Gold = gold;
        }

        // 레벨 당 스탯 증가 메서드 구현 예정
        // 
    }

    public class Monster // 몬스터 클래스
    {
        public string Name { get; }
        public int Level { get; }
        public int Hp { get; set; }
        public int Atk { get; set; }

        public static int MonsterCnt = 0; // 몬스터 배열 표시에 사용, static


        public Monster(string name, int level, int hp, int atk)
        {
            Name = name;
            Level= level;
            Hp = hp;
            Atk= atk;
         }

    }

    public class Dungeon
    {
        public string Name { get; set; }
        public int Difficulty { get; set; }
        public List<Monster> Monsters { get; set; }

        public Dungeon(string name, int difficulty)
        {
            Name = name;
            Difficulty = difficulty;
            Monsters = new List<Monster>();
        }
        public void DifficultyLevelMonsters() // 난이도별 몬스터 출력
        {
            while (true)
            {
                Console.WriteLine("난이도를 선택하세요 (1: 쉬움, 2: 보통, 3: 어려움, 4: 헬조선): ");
                Difficulty = int.Parse(Console.ReadLine());

                if (Difficulty == 1)
                {
                    // 쉬운 난이도
                    Monsters.Add(new Monster("미니언", 2, 15, 5));
                    break;
                }
                else if (Difficulty == 2)
                {
                    // 보통 난이도 
                    Monsters.Add(new Monster("강한 미니언", 4, 20, 10));
                    break;
                }
                else if (Difficulty == 3)
                {
                    Monsters.Add(new Monster("거대한 미니언", 4, 20, 10));
                    // 어려운 난이도
                }
                else if (Difficulty == 4)
                {
                    Monsters.Add(new Monster("인터넷 전문가", 20, 50, 80));
                    //헬조선 난이도
                    break;
                }
                else // 잘못 된 입력 시 다시 while
                {
                    Console.WriteLine();
                }

            }
        }
    }

        public class Item // 아이템 클래스
    {
        public string Name { get; }
        public string Desctription { get; }
        public int Type { get; }  //    0.방어구 | 1.무기  
        public int Atk { get; set; }
        public int Def { get; set; }

        // public int Hp { get; }   물약 구현 때문에 아이템에도 int hp를 해봐야하나? 일단 대기
        public int Gold { get; set; }
        public bool IsEquipped { get; set; } // 장착 여부
        public bool IsPurchased { get; set; } // 구매 여부

        public static int ItemCnt = 0; // 아이템 배열 표시에 사용, 게임 전체에 공유 됨.

        public Item(string name, string description, int type, int atk, int def, int gold, bool isEquipped = false, bool isPurchased = false)
        {
            Name = name;
            Desctription = description;
            Type = type;
            Atk = atk;
            Def = def;
            Gold = gold;
            IsEquipped = isEquipped;    // 장착 여부
            IsPurchased = isPurchased;  // 구매 여부
        }

        public void PrintItemStatDescription(bool withNumber = false, int idx = 0, bool showPrice = false ) 
            // 아이템 스탯 및 번호 출력 관련 함수
        {
          Console.WriteLine("- ");

            if (withNumber) // 아이템 번호 표시 + 컬러링
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("{0} ", idx);
                Console.ResetColor();
            }
            if (IsEquipped) // 아이템 착용 시 + 컬러링
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Cyan; //   [ 의 뒤의 색 변경
                Console.Write("E"); // cyan 컬러
                Console.ResetColor(); // 색 리셋
                Console.Write("]");
                Console.Write(PadRightForMixedText(Name, 9)); // 장착 중인 경우는 9글자 출력, 텍스트 정렬 함수 사용
            }
            // 0이 아니라면 출력할건데, + 삼항 연산자 조건에 따라 할 거야.
            if (Atk != 0) Console.Write($"Atk {(Atk >= 0 ? " + " : "")}{Atk}"); // 스탯이 0보다 크거나 같으면 "+" 를 붙이고 아니면 " "해라(공백).
            if (Def != 0) Console.Write($"Def {(Def >= 0 ? " + " : "")}{Def}");
        }

        public static string PadRightForMixedText(string str, int totalLength) // 텍스트 정렬
        {
            int currentLength = GetPrintableLength(str); // 텍스트의 실제 길이
            int padding = totalLength - currentLength; //  총길이 - 실제길이 = int padding 추가해야 할 길이
            return str.PadRight(str.Length + padding); // padding 만큼 PadRight(문자열의 오른쪽)에 공백을 추가
        }
        public static int GetPrintableLength(string str) // 아이템 텍스트 정렬을 위해 문자별 legnth 판정 정의
        {
            int length = 0;
            foreach (char c in str)
            {
                if (char.GetUnicodeCategory(c) == System.Globalization.UnicodeCategory.OtherLetter)
                {
                    length += 2; // 한글과 같은 넓은 문자는 길이를 2로 취급
                }
                else
                {
                    length += 1; // 나머지 문자는 길이를 1로 취급
                }
            }
            return length;
        }
    }


    internal class Program
    {
        static Character _player;
        static Item[] _items;
        static Monster[] _monster;
        static Random _random = new Random(); //  랜덤 숫자를 생성하는 데 사용 (몬스터 등)

        static void Main(string[] args)
        {
           
            GameDataSetting();
            PrintStartLogo();
            StartMenu(); // 시작 메뉴
            //CreatePlayerMenu(); // 캐릭터 생성 메뉴, 추후 만들면 StartMenu랑 스왑 예정, 일단 구현 X
        }

        private static void GameDataSetting() // 게임 데이터 세팅
        {
            _player = new Character("정진", "백수", 1, 10, 5, 100, 3000); // 이름 직업 레벨 공격력 방어력 체력 골드

            // 몬스터, 아이템 배열 사용
            _monster = new Monster[4];
            AddMonster(new Monster("미니언", 2, 15, 5));
            AddMonster(new Monster("공허충", 3, 10, 9));
            AddMonster(new Monster("대포 미니언", 5, 25, 8));
            AddMonster(new Monster("버섯을 든 티모", 6, 20, 9)); // 추가 몬스터

            _items = new Item[6];
            AddItem(new Item("냄비 뚜껑", "라면을 끓일 때 쓰는 냄비에 알맞을 것 같습니다. ", 0, 0, 5, 1000)); // 맨 앞의 숫자가 0이면 방어구, 1이면 무기
            AddItem(new Item("노스페이스 패딩", "한 때 유행했으나 지금은 어머니들이 착용하는 방한복입니다. ", 0, 0, 9, 2000));
            AddItem(new Item("스파르타의 갑옷", "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.", 0, 0, 15, 3500));
            AddItem(new Item("당근 칼", "잼민이들이 이 무기를 좋아합니다.", 1, 2, 0, 600));
            AddItem(new Item("나무 목검", "쉽게 볼 수 있는 낡은 검입니다.", 1, 5, 0, 1500));
            AddItem(new Item("스파르타의 창", "스파르타의 전사들이 사용했다는 전설의 창입니다.", 1, 7, 0, 3000));
        }



        private static void AddMonster(Monster monster)
        {
            if (Monster.MonsterCnt == 4)
            {
                return; // monster 클래스 객체의 Cnt 변수가 4이면 아무 것도 안 만든다.
            }
            _monster[Monster.MonsterCnt] = monster;  //  0~4까지 ++
            Monster.MonsterCnt++;
        }

        private static void AddItem(Item item)
        {
            if (Item.ItemCnt == 6)
            {
                return; // Item클래스 객체의 ItemCnt 변수가 6이면 아무 것도 안 만든다.
            }
            _items[Item.ItemCnt] = item;  // 위 조건문과 연동하여 0에서 6까지 ++
            Item.ItemCnt++;
        }

        public static int CheckValidInput(int min, int max) // 입력 값 유효성 확인 함수
        {
            // 아래 두 가지 상황이면 비정상이고, 재입력 수행하는 로직
            // 1. 숫자가 아닌 입력을 받은 경우, 2. 숫자가 최솟값 에서 최댓값의 범위를 벗어난 경우

            int keyInput; // 입력한 번호(문자열) -> tryParse(정수화)에 사용할 것.
            bool result;  // while 반복문에 필요
            do // 일단 한 번 실행
            {
                Console.WriteLine("\n원하시는 행동 번호를 입력 해주세요.");
                result = int.TryParse(Console.ReadLine(), out keyInput);
                // 리드라인 입력값을 정수 변환하여 int KeyInput에 저장하고, 결과 값을 result로 정의.
                // int.TryParse()는 입력값이 정수면 true인데, 그 외면 false를 반환 == result가 false
                // 즉, 결과 값이 숫자(정수)면 가져오고, 그 외면 안 가져옴 -> 아래 while 조건 발동

                if (result == false || CheckIfValid(keyInput, min, max) == false) // 잘못된 입력 메세지 출력을 위해 if문 추가
                {
                    Console.WriteLine("!! 잘못된 입력입니다. 다시 시도해주세요 !!");
                    Console.WriteLine("   아무 키나 누르면 돌아갑니다. ");
                    Console.ReadKey();
                }
            }
            while (result == false || CheckIfValid(keyInput, min, max) == false);
            // result가 false거나 CheckIfVaild함수가 false면 while 반복 
            return keyInput;
            //여기에 도착했다는 것은 (아래 유효성 확인 bool 함수를 통해) 제대로 입력을 받았다(true)는 것.
        }
        internal static bool CheckIfValid(int keyInput, int min, int max) // 입력 값 유효성 확인 함수 2  bool
        {
            if (min <= keyInput && keyInput <= max) // keyInput이 min 이상 이면서 ketinput이 max 이하면
            {
                return true; // true 반환 = 실행
            }
            return false; // 그 외면 false 반환
        }

        private static void ShowHighlightText(string text) // 전체 줄 색 변경 함수, 마젠타 색
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        private static void PrintTextWithHighlights(string s1, string s2, string s3 = "") // 문자열 중간 색 변경 함수 ,  
                                                                                          // 상태 보기에서 사용될건데, s1은 명칭 / s2는 현재 스탯 / s3은 추가 스탯
                                                                                          // s2만 노란색으로 바꿔줄 것.
        {
            Console.Write(s1);
            Console.ForegroundColor = ConsoleColor.Yellow; // 노란색 발동 -> s2에 적용
            Console.Write(s2);
            Console.ResetColor(); // 색 리셋
            Console.WriteLine(s3);
        }


        private static void PrintStartLogo() // 게임 스타트 화면, 미사용
        {
            Console.WriteLine("==================================================================");
            Console.WriteLine("     ___________________   _____  __________ ___________ _____");
            Console.WriteLine("     \\_____  \\  |     ___//  /_\\  \\ |       _/  |    |  /  /_\\  \\ ");
            Console.WriteLine("     /        \\ |    |   /    |    \\|    |   \\  |    | /    |    \\");
            Console.WriteLine("    /_______  / |____|   \\____|__  /|____|_  /  |____| \\____|__  /");
            Console.WriteLine("            \\/                   \\/        \\/                  \\/");
            Console.WriteLine("________    ____ ___ _______     ________ ___________________    _______ ");
            Console.WriteLine("\\______ \\  |    |   \\\\      \\   /  _____/ \\_   _____/\\_____  \\   \\      \\");
            Console.WriteLine(" |    |  \\ |    |   //   |   \\ /   \\  ___  |    __)_  /   |   \\  /   |   \\");
            Console.WriteLine(" |    `   \\|    |  //    |    \\\\    \\_\\  \\ |        \\/    |    \\/    |    \\");
            Console.WriteLine("/_______  /|______/ \\____|__  / \\______  //_______  /\\_______  /\\____|__  /");
            Console.WriteLine("        \\/                  \\/         \\/         \\/         \\/         \\/");
            Console.WriteLine("==============================================================================");
            Console.WriteLine("                            PRESS ANYWAY TO START                             ");
            Console.WriteLine("==============================================================================");
            Console.ReadKey(); // 아무 키나 입력 받음
        }

        private static void CreatePlayerMenu() // 플레이어 생성 메뉴, 미구현
        {
            throw new NotImplementedException();
        }

        private static void StartMenu()
        {
            Console.Clear();
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine();
            Console.WriteLine("");
            Console.WriteLine("1. 상태 보기");
            //Console.WriteLine("2. 인벤토리");
            //Console.WriteLine("3. 상점");
            Console.WriteLine("4. 전투 시작");
            //Console.WriteLine("5. 휴식");
            //Console.WriteLine("6. 게임 저장 및 불러오기");
            //Console.WriteLine("7. 게임 종료");
            Console.WriteLine("");

            switch (CheckValidInput(1, 7))
            {
                case 1:
                    StatusMenu(); // 1. 상태보기
                    break;
                case 2:
                    StartBattle();
                    break;
                case 3:
                    StartBattle();
                    break;
                case 4:
                    StartBattle(); ;  // 4. 전투시작,  다른 곳에도 임시로 다 전투시작 넣어둠
                    break;
                case 5:
                    StartBattle();
                    break;
                case 6:
                    StartBattle();
                    break;
                case 7:
                    StartBattle();
                    break;
            }
        }


        private static void StatusMenu() // 상태 보기 메뉴
        {
            Console.Clear();
            ShowHighlightText("■ 상태 보기 ■");
            Console.WriteLine("캐릭터의 정보가 표기됩니다.");
            Console.WriteLine("");
            PrintTextWithHighlights("Lv ", _player.Level.ToString("00"));
            Console.WriteLine("");
            Console.WriteLine("{0} ({1})", _player.Name, _player.Job);

            // 합산 공격력, 방어력 구현
            int bonusAtk = GetSumBonusAtk(); // 장비 장착시 추가되는 스탯 표시 및 총 공격력 계산에 사용
            int bonusDef = GetSumBonusDef(); // 동일

            PrintTextWithHighlights("공격력 : ", (_player.Atk + bonusAtk).ToString(), bonusAtk > 0 ? string.Format(" (+{0})", bonusAtk) : " ");
            // 플레이어 공격력 + 보너스 공격력을 문자열로 반환 + (삼항연산자) 보너스 공격력이 0보다 크면 +(보너스 어택) 문자열을 출력해주고, 아니면은 빈칸을 추가

            PrintTextWithHighlights("방어력 : ", (_player.Def + bonusDef).ToString(), bonusDef > 0 ? string.Format(" (+{0})", bonusDef) : " ");
            PrintTextWithHighlights("체력 : ", _player.Hp.ToString());
            PrintTextWithHighlights("골드 : ", _player.Gold.ToString());
            // 공 방 체력 골드 다 Tostring 한 이유는
            // PrintTextWithHighlights 함수의 매개변수가 string인데 (s1, s2, s3)  스탯의 자료형은 Int이므로, s2의 노란색 컬러를 적용 시키기 위해 Tostring 변환해줌.

            Console.WriteLine("");
            Console.WriteLine("0. 뒤로가기");
            Console.WriteLine("");

            switch (CheckValidInput(0, 0)) // 0번 나가기
            {
                case 0:
                    StartMenu();
                    break;
            }
        }

        private static int GetSumBonusDef() // 추가 방어력 합산
        {
            int sum = 0; // 능력치를 다 더 할 것 
            for (int i = 0; i < Item.ItemCnt; i++)   // 아이템을 전부 확인
            {
                if (_items[i].IsEquipped) sum += _items[i].Def;
                // 아이템 목록의 아이템이 장착되어 있다면, 장착 아이템의 Def를 다 더하라.
            }
            return sum; // 그 후 sum에게 값을 반환
        }

        private static int GetSumBonusAtk() // 추가 공격력 합산
        {
            int sum = 0;
            for (int i = 0; i < Item.ItemCnt; i++)
            {
                if (_items[i].IsEquipped) sum += _items[i].Atk;
            }
            return sum;
        }



        private static void StartBattle() // 전투 시작 
        {
            Console.WriteLine("");
            ShowHighlightText("■ Battle !! ■");
            Console.WriteLine("");

            int numMonsters = _random.Next(1, 5); // 전투에 참여할 몬스터 수 랜덤으로 선택, 1~4

            Monster[] battleMonsters = new Monster[numMonsters]; // 전투 참여할 몬스터의 객체 배열 생성

            for (int i = 0; i < numMonsters; i++)
            {
                // _monster 배열에서 랜덤한 몬스터를 선택하여 전투 배열에 추가
                int monsterIdx = _random.Next(_monster.Length);
                battleMonsters[i] = _monster[monsterIdx]; // 랜덤 몬스터를 battleMonsters에 할당
            }
            // 위에서 랜덤 생성된 몬스터 출력
            for (int i = 0; i < battleMonsters.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {battleMonsters[i].Name} Lv.{battleMonsters[i].Level} - HP {battleMonsters[i].Hp}");
            }

            //
            while (IsBattleOver(battleMonsters) == false) // 전투가 끝날 때까지 루프 시작
            {
                PlayerTurn(battleMonsters);  // 플레이어가 먼저 공격
                MonsterTurn(battleMonsters); 
            }
            DisplayBattleResult(battleMonsters); // 전투 결과 출력
        }

        private static bool IsBattleOver(Monster[] battleMonsters) // 전투 종료 검사 bool
        {
            return battleMonsters.All(m => m.Hp <= 0) || _player.Hp <= 0; 
            // 몬스터 전체 체력이 0보다 이히거나 플레이어의 체력이 0보다 이하면 true 
        }   // m = 람다 표현식 (생성 된 몬스터 각 객체)


        private static bool IsValidTarget(Monster[] battleMonsters, int choice)  // 공격 타겟 유효성 검사 bool
        {
            return choice > 0 && choice <= battleMonsters.Length && battleMonsters[choice - 1].Hp > 0;
        }
        // 선택값이 몬스터 범위 내에서 유효한지 확인하고 -1 해서 배열 인덱스 맞추고 몬스터 체력이 0보다 커야 작동 (0이하는 유효하지 않다 = dead)


        private static void PlayerTurn(Monster[] battleMonsters) // 플레이어의 턴
        {
            Console.Clear();
            int choice = 0;
            bool isValidChoice = false;
            while (isValidChoice == false)
            {
                Console.WriteLine("\n플레이어의 턴입니다. 공격할 몬스터를 선택하세요:");
                for (int i = 0; i < battleMonsters.Length; i++) // 몬스터 순회해서 출력
                {
                    Console.WriteLine($"{i + 1} - {battleMonsters[i].Name} Lv.{battleMonsters[i].Level} - HP {battleMonsters[i].Hp}");
                }

                Console.Write("선택: "); // 
                if (int.TryParse(Console.ReadLine(), out choice) && IsValidTarget(battleMonsters, choice))
                    // 입력이 정수면 = choice에 저장,  플레이어 선택한 몬스터의 유효성 검사, 틀리면 위로 반복
                {
                    isValidChoice = true; // 유효하면 true 
                    int selectedMonsterIdx = choice - 1; // 배열 인덱스 땜에
                    AttackMonster(_player, battleMonsters[selectedMonsterIdx]); // 플레이어의 공격 메서드 실행
                }
                else
                {
                    Console.WriteLine("잘못된 선택입니다.");
                }
            }
        }
        private static void MonsterTurn(Monster[] battleMonsters) // 몬스터 턴
        {
            Console.Clear();
            foreach (var monster in battleMonsters) // 모든 몬스터에 적용
            {
                if (monster.Hp > 0) 
                {
                    AttackPlayer(_player, monster); // 몬스터가 플레이어 공격
                }
            }
        }


        private static void AttackMonster(Character player, Monster monster) // 플레이어가 몬스터 공격
        {

            int baseDamage = player.Atk; // 기본 데미지 = 기본 플레이어 공격력 설정  (추후 아이템 추가시 총 공격력으로 대체 예정) 
            int damageVariation = (int)Math.Round(baseDamage * 0.1); // 공격력의 10%가 랜덤 반영, 소수점이 있다면 반올림 처리

            // 최종 공격력에 합산
            int damage = _random.Next(baseDamage - damageVariation, baseDamage + damageVariation + 1 );
            // 계산식1 , 그냥 기본데미지 , 계산식2  셋중에 하나 랜덤 적용
            // +1은 랜덤 갯수(범위)를 늘려준다는 뜻, 안해주면 2종류 랜덤 결과 밖에 안 나옴.

            // 타겟에게 데미지를 적용
            monster.Hp -= damage;

            // 타겟의 체력이 0 이하가 되면 죽은 상태로 표시
            if (monster.Hp <= 0)
            {
                monster.Hp = 0;
                Console.WriteLine($"{monster.Name}, // Dead"); // 아직 hp 표시 없고 bool로 dead랑 hp랑 스왑 예정
            }
            else
            {
                Console.WriteLine($"{player.Name}의 공격!"); 
                Console.WriteLine($"[데미지 : {damage}");
            }
        }


        private static void AttackPlayer(Character player, Monster monster) // 몬스터가 플레이어 공격
        {
            int damage = monster.Atk;
            player.Hp -= damage;
            Console.WriteLine($"{monster.Name}의 공격! ");
            Console.WriteLine($"{player.Name}를 맞췄습니다.  데미지 : {damage}");
        }

        private static void DisplayBattleResult(Monster[] battleMonsters) // 전투 결과 판단
        {
            if (_player.Hp <= 0)
            {
                 PlayerLose();
            }
            else if (battleMonsters.All(m => m.Hp <= 0))
            {
                PlayerVictory();
            }
        }
        private static void PlayerVictory() // 승리 페이지
        {
            Console.WriteLine("Battle!! - Result");
            Console.WriteLine();
            Console.ReadKey();


            // 텍스트 구현 예정
            // 다음 진행 구현 예정
        }


        private static void PlayerLose() // 패배 페이지
        {
            Console.WriteLine("Battle!! - Result");
            Console.WriteLine();
            Console.ReadKey();
            

            // 텍스트 구현예정
            // 다음 진행 구현 예정
        }


    }
}
