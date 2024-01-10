
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

    // 4. 나만의 기능을 만들어 보기, 개인 개선
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



    public enum JobType // 직업 enum
    {
        Warrior,
        Mage,
        Theif,
        Programmer,
    }

    public class Character
    {
        public string Name { get; } // 이름 및 직업은 생성 시에만 설정하고, 게임 중에는 바뀌지 않기 때문에 get;만 설정
        public JobType Job { get; }
        public int Level { get; set; }
        public int Exp { get; set; } // 경험치
        public int Atk { get; set; }
        public int Def { get; set; }

        //public int Speed { get; set; } // Atk, Def 처럼 레벨업에 따라 변하며, 아이템 장착 유무 및 회피 기능에 연관
        public int Hp { get; set; }
        public int Mp { get; set; }
        public int Gold { get; set; }


        public Character(string name, JobType job, int level, int exp, int atk, int def, int hp, int mp, int gold)
        {
            Name = name;
            Job = job;
            Level = level;
            Exp = exp;
            Atk = atk;
            Def = def;
            //Speed = speed; // 일단 pass
            Hp = hp;
            Mp = mp;
            Gold = gold;
        }

        // 레벨 당 스탯 증가 메서드 구현 예정
        // 
    }



    public class Monster
    {
        public string Name { get; }
        public int Level { get; }
        public int Hp { get; set; }
        public int Atk { get; set; }


        public Monster(string name, int level, int hp, int atk)
        {
            Name=name;
            Level= level;
            Atk= atk;
        }

    }


    public class Item
    {
        public string Name { get; }
        public string Desctription { get; }
        public int Type { get; }  // 3개로 할까 함, 무기-방어구-악세서리
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Gold { get; set; }
        public bool IsEquipped { get; set; } // 장착 여부
        public bool IsPurchased { get; set; } // 구매 여부

        public static int ItemCnt = 0; // 아이템 종류 표시에 사용, 게임 전체에 공유 됨.

        public Item(string name, string description, int type, int atk, int def, int gold, bool isEquipped = false, bool isPurchased = false)
        {
            Name = name;
            Desctription = description;
            Type = type;
            Atk = atk;
            Def = def;
            Gold = gold;
            IsEquipped = isEquipped;
            IsPurchased = isPurchased;
        }

        public void PrintItemStatDescription(bool withNumber = false, int idx = 0, bool showPrice = false ) 
            // 아이템 스탯 및 번호 출력 관련 함수
        {
          Console.WriteLine("- ");

            if (withNumber) // 7-4 아이템 번호 컬러
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write("{0} ", idx);
                Console.ResetColor();
            }
            if (IsEquipped) // 아이템 착용 시
            {
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Cyan; //   [ 의 뒤의 색 변경
                Console.Write("E"); // cyan 컬러
                Console.ResetColor(); // 색 리셋
                Console.Write("]");
                Console.Write(PadRightForMixedText(Name, 9)); // 장착 중인 경우는 9글자 출력, 텍스트 정렬 함수 사용
            }
            // 0이 아니라면 출력해라 + 삼항 연산자
            if (Atk != 0) Console.Write($"Atk {(Atk >= 0 ? " + " : "")}{Atk}");  // 공격력이 0보다 크거나 같으면 "+" 를 붙이고 아니면 " "해라(공백).
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
        static Monster _monster;

        static void Main(string[] args)
        {
            PrintStartLogo();
            StartMenu(); // 시작 메뉴
            //CreatePlayerMenu(); // 캐릭터 생성 메뉴, 추후 만들면 StartMenu랑 스왑 예정, 일단 구현 X
        }

        private static void PrintStartLogo()
        {
            throw new NotImplementedException();
        }

        private static void GameDataSetting() // 게임 데이터 세팅
        {

        }

        private static void CreatePlayerMenu()
        {
            throw new NotImplementedException();
        }

        private static void StartMenu()
        {
            throw new NotImplementedException();
        }




    }
}
