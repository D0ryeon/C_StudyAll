using System.Diagnostics.CodeAnalysis;
using System.Net.Security;
using System.Reflection.Metadata.Ecma335;

namespace HamIne_Dungeon
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Character player = new Character("햄이네", "전사");
            Inventory inv = new Inventory();
            List<Item> inventory = inv.items;
            StartView();
            while (true)
            {
                Console.Clear();

                // test Space 
                /*for(int i = 0; i < inventory.Count ; i++)
                {
                    Console.WriteLine(inventory[i].name);
                }
                inv.removeItem("test1");
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.WriteLine(inventory[i].name);
                }

                Console.WriteLine("장난감검 추가");
                inv.addItem(new Item("장난감검","장난감검이다",5,0,100));
                for (int i = 0; i < inventory.Count; i++)
                {
                    Console.WriteLine(inventory[i].name);
                }*/

                // 위는 삭제할것




                Console.WriteLine("햄이네 마을에 오신 여러분 환영합니다.");
                Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
                Console.WriteLine();
                Console.WriteLine("1. 상태 보기");
                Console.WriteLine("2. 인벤토리");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
                string inputNum = Console.ReadLine();

                switch (inputNum)
                {
                    case "1":
                    status:
                        Console.Clear();

                        StatusView();

                        string inputStatus = Console.ReadLine();

                        switch (inputStatus)
                        {
                            case "0":
                                break;
                            default:
                                Console.WriteLine("올바른 번호를 적어주세요.");
                                goto status;
                        }

                        break;
                    case "2":
                    invenMenu:
                        Console.Clear();

                        InventoryView();

                        string inputInventory = Console.ReadLine();
                        switch (inputInventory)
                        {
                            case "0":
                                break;
                            case "1":
                            iquipMenu:
                                Console.Clear();
                                InventoryEquipView();

                                string inputIquip = Console.ReadLine();
                                int num = 0;
                                bool isNum = int.TryParse(inputIquip, out num);
                                if (num < inventory.Count)
                                {
                                    if (inventory[num].equip == false)
                                    {
                                        inventory[num].equip = true;
                                    }
                                    else
                                    {
                                        inventory[num].equip = false;
                                    }
                                }
                                if (inputIquip == "0")
                                {
                                    goto invenMenu;
                                }
                                else if (num >= inventory.Count || isNum == false)
                                {
                                    Console.WriteLine("올바른 번호를 적어주세요.");
                                    Console.ReadLine();
                                    goto iquipMenu;
                                }
                                goto iquipMenu;
                            default:
                                Console.WriteLine("올바른 번호를 적어주세요.");
                                Console.ReadLine();
                                goto invenMenu;
                        }
                        break;
                    default:
                        Console.WriteLine("올바른 번호를 적어주세요.");
                        Console.ReadLine();
                        continue;
                }
            }

            int[] EquipStatus()
            {
                // equip[0] : 착용 장비 총 공격력
                // equip[1] : 착용 장비 총 방어력
                int[] equip = { 0, 0 };
                int sum = 0;
                for (int i = 0; i < inventory.Count; i++)
                {
                    if (inventory[i].equip == true)
                    {
                        if (inventory[i].damage != 0)
                        {
                            equip[0] += inventory[i].damage;
                            sum++;
                        }
                        else if (inventory[i].defense != 0)
                        {
                            equip[1] += inventory[i].defense;
                            sum++;
                        }
                    }
                }
                if (sum == 0)
                {
                    return null;
                }
                return equip;
            }

            // 상태창 뷰
            void StatusView()
            {
                int[] equip = EquipStatus();
                Console.WriteLine("상태보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.");
                Console.WriteLine();
                Console.WriteLine("Lv. " + player.level);
                Console.WriteLine("Chad ( " + player.chad + " )");
                // 장비가 적용된 공격력 방어력 
                Console.Write("공격력 : " + player.damage);
                if (!(equip == null))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" ( + " + equip[0] + " )");
                    Console.ResetColor();
                }
                Console.Write('\n');
                Console.Write("방어력 : " + player.defense);
                if (!(equip == null))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" ( + " + equip[1] + " )");
                    Console.ResetColor();
                }
                Console.Write('\n');

                Console.WriteLine("체 력 : " + player.HP);
                Console.WriteLine("소지금 : " + player.gold + " G");
                Console.WriteLine();
                Console.WriteLine("0. 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
                Console.Write(">>");
            }


            // start view
            void StartView()
            {
                string[] str = {
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,..,,,..,,;    .....        ;1.........   1  ............. ....fLLG...LLLLLLLLftfLfffLLLfi1LfffLC,,. ",
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,..,,1                  t t            G                   ..LLL@..fLLLLftLLLLLLLt1fLLLLLLLt1;,,,,,",
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,t                  f  t         ...;t                  ..;LLLG:;LffLLLLLLtffLLLLLLf1fLLGf,,,,,,",
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,i                 .t   C       .....:8;.               ....LLLLC1LLLLLffLLLLLLLfLLLC08C,,,,,,,,,",
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,             .....i    C........f...:0 :.....         .....tLLLLL @LLLLLLLLLLLLLL0,,,,,,,,,,,,,,,",
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,         .........:.     ,......:@...iC  .:.................;LLLLLL0LLLLLLLLLLLLLL0,,,,,,,,,,,,,,",
"     ..,,,,,,,,,,,,,,,,,,,,,,,,i  .................1,1fLCG0G080008GCCf00,   f................:LLLLLLLGLLLLLLLLLLLLG,,,,,,..    ...",
",,,,,,,,,,,.  ...,,,,,,,,,,,,,; .................ifLf      t ,,.fL ,L1G0tf11fC81.............,LLLLLLLLCLLLCCCCGCt. ..,.... ..,,,,,",
",,,,,,...,,,,,,,,,,,,,.....,,,..................fL;                           G0.............:LLLLLLLLLLf11i......,,,,,,.........,",
"    ......,,,,,,,,,,,,,,,,,,,:.................,@0.   \"       :;;1i      \"     G0f............tLLLLLLLLLLC,,,,,,,,,,,,,,,,,,,,..",
",,,,,,,,,,,,,,,,,,,.,.,.,.,,;..................L@C       ,LfG: ●iGCL         G@ @...........LLLLLLLLLLLLG,,,,,,,,,,,,..........  ",
",,,,,,,,,,,,..... ...,...,,...................LG,0f:::iCC01    ㅣ    t0fL    iG0:..Cf........fLLLLLLLLLLLLL;,,,,,,,,...,.........,",
",,,,,,,,,,,,,,,,,,,,,,,,,,,f.................1L8..,111:.;f1i1Ci,iCt1;;if0CGGf,....ff@,.....;LLLLLLLLLLLLLLL,,,,,,,,,,,,,,,,,,,,,,,",
",,,,,,,,,,,,,,,,,,,,,,,,,,;.................,LG,           ;          C        ...:fff8...:LLLLLLLLLLLLLLLLt,,,,,,,,,,,,,,,,,,,,,,",
",,,,,,,,,,,,,,,,,,,,,,,,,,C.................LL@             C         0           .ffffCf:LLLLLLLLLLLL@LLLLC,,,,,,,,,,,,,,,,,,,,,,",
",,,,,,,,,,,,,,........,,,,:................fLL;             .;        C            fttttt8GLLLLLLLLLLLL;0LLf,,,,,,,,,,,,,,,,,,,,,,",
".      .,,,,,,,,,,,..,,,,:................;LL8               G        t            ttttttL,fCLLLLLLfLLLC,,,,......,,,,,,,,,,,,,,,,",
",,,,,,,.......,,,,,,,,,,,:................LLL@                G      1.           ,tttttf;,,,;CLLLLLLLL:....,,,.....,,,. ....,,,,,",
"  .,,,,,,,,,,,,,,....,,,,,L......,.......fLLL@                ,i     0            tttttf;,,,,,,,iCCLLG;,,,,,,,,.. ..,,,,.....,,,,.",
",.....,,,.....,,,,,,,,,,,,,t;.,iif......;LLLL1                 G     G           ,ttttGCCfi,,,,,,,,,,,,,,,,,,,,,,,,,,,,.  ..,,,,..",
",... .,,,,,,,,,,,,,,,,,,,,,,,,,,,f......LLLL01                  0   L            tttt@tttttttC0L;,,,,,,,,,,,,,,,,,,,,,..,,,,,,.   ",
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,.....LLLLLi,C,                 f,;G          .ttt8Ltttttttttt11iit1,,,,,,,,,,,,,,,,,,,,,,....,,,",
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,L.:LLLLLLf,,,,Li                            ttf8tttGtttt1             i,,,,,,,,,,,,,,,,,,,,,,,,.",
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,fCLLLL0,,:f1    Li                     ,1tf@@@@ttttCtt,                .8,,,,,,,,,,,,,,,,,,,,,,",
",,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,;,,tL            1fi,       ,:ittfLC8@@@@@@@ttf0fi                   .t0,,,,,,,,,,,,,,,,,,,,"
                };

                for (int i = 0; i < str.Length; i++)
                {
                    Console.WriteLine(str[i]);
                }
                Console.WriteLine(String.Format("{0}", "PRESS ENTER KEY TO START").PadLeft(130 - (65 - ("PRESS ENTER KEY TO START".Length / 2))));
                Console.ReadLine();
            }



            // 인벤토리 뷰
            void InventoryView()
            {
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                for (int i = 1; i < inventory.Count; i++)
                {
                    Console.Write("- ");
                    if (inventory[i].equip == true)
                    {
                        Console.Write(" [E]\t");
                    }
                    else
                    {
                        Console.Write("\t");
                    }
                    Console.Write(inventory[i].name);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("   \t| ");
                    Console.ResetColor();
                    if (inventory[i].damage != 0)
                    {
                        Console.Write("공격력 ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("+" + inventory[i].damage);
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" | ");
                        Console.ResetColor();
                    }
                    else if (inventory[i].defense != 0)
                    {
                        Console.Write("방어력 ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("+" + inventory[i].defense);
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" | ");
                        Console.ResetColor();
                    }
                    Console.Write(inventory[i].content);
                    Console.Write('\n');
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("1");
                Console.ResetColor();
                Console.WriteLine(". 장착관리");
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("0");
                Console.ResetColor();
                Console.WriteLine(". 나가기");
                Console.WriteLine();
                Console.WriteLine("원하시는 행동을 입력해주세요.");
            }


            // 장비착용 뷰
            void InventoryEquipView()
            {
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다");
                Console.WriteLine();
                Console.WriteLine("[아이템 목록]");
                for (int i = 1; i < inventory.Count; i++)
                {
                    Console.Write("- ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.Write(i + ".");
                    Console.ResetColor();
                    if (inventory[i].equip == true)
                    {
                        Console.Write(" [E]\t");
                    }
                    else
                    {
                        Console.Write("\t");
                    }
                    Console.Write(inventory[i].name);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write("   \t| ");
                    Console.ResetColor();
                    if (inventory[i].damage != 0)
                    {
                        Console.Write("공격력 ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("+" + inventory[i].damage);
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" | ");
                        Console.ResetColor();
                    }
                    else if (inventory[i].defense != 0)
                    {
                        Console.Write("방어력 ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("+" + inventory[i].defense);
                        Console.ResetColor();
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" | ");
                        Console.ResetColor();
                    }
                    Console.Write(inventory[i].content);
                    Console.Write('\n');
                }
                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.Write("0");
                Console.ResetColor();
                Console.WriteLine(". 나가기");
                Console.WriteLine();
                Console.WriteLine("장착하고 싶은 장비의 번호를 입력해주세요.");
            }
        }

        void encoding(string[] str)
        {
            System.Text.Encoding utf8 = System.Text.Encoding.UTF8;


        }
    }


    public class Character
    {
        public string name { get; }
        public string chad { get; }
        public int level { get; }
        public int exp { get; }
        public int damage { get; }
        public int defense { get; }
        public int HP { get; }
        public int gold { get; set; }

        public Character(string name, string chad)
        {
            this.name = name;
            this.chad = chad;
            this.level = 1;
            this.exp = 0;
            this.damage = 10;
            this.defense = 5;
            this.HP = 100;
            this.gold = 0;
        }

        //장비착용
        //    장비마다 스테이터스 증가

        //    장비를 빼면 스테이터스 감소

        //몬스터에게 맞을 시
        //    체력감소
        //    체력 0이되면 게임오버

        //몬스터를 쓰러트릴때
        //    경험치 증가
        //    레벨업
        //    골드수급



    }

    public class Item
    {
        public bool equip { get; set; }
        public string name { get; }
        public string content { get; }
        public int damage { get; }
        public int defense { get; }
        public int gold { get; }

        public Item(string name, string content, int damage, int defense, int gold)
        {
            this.name = name;
            this.content = content;
            this.damage = damage;
            this.defense = defense;
            this.gold = gold;
            this.equip = false;
        }
    }

    public class Inventory
    {
        public List<Item> items { get; set; }
        public Inventory()
        {
            items = new List<Item>();
            addItem(new Item("0", "0", 0, 0, 0));
            addItem(new Item("무쇠갑옷", "햄이네가 주워온 종이상자입니다. 매직으로 무쇠갑옷이라 써 있습니다.", 0, 1, 0));
            addItem(new Item("전설의 검", "햄이네가 전설의 검이라고 이름 붙인 나뭇가지입니다. 용감해진 기분입니다", 1, 0, 0));
            addItem(new Item("강철투구", "평범한 빨간색 바가지입니다. 매직으로 까맣게 칠해져 있습니다.", 0, 1, 0));
        }

        public void addItem(Item item)
        {
            items.Add(item);
        }

        public void removeItem(string itemName)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].name == itemName)
                {
                    items.Remove(items[i]);
                    Console.WriteLine("저런 " + itemName + "을 잃으셨군요");
                }
            }
        }
    }

    public class Shop
    {
        public List<Item> shop { get; set; }

        public Shop()
        {
            shop = new List<Item>();
            addShop(new Item("고글", "햄이네의 잃어버렸던 고글, 사실 침대옆에 짱박혀있었다.", 0, 3, 100));
            addShop(new Item("비둘기", "지나가던 비둘기, 진짜 그냥 비둘기이다.", 0, 0, 9));
            addShop(new Item("돌잔치모자", "돌잔치에 썻던 모자", 0, 4, 400));
            addShop(new Item("아잉눈", "햄이네가 끼면 필살기", 6, 0, 1000));
            addShop(new Item("홍삼스틱", "이걸 보자 햄이네가 도망쳤다", 9, 0, 2400));
            addShop(new Item("도끼", "아이네가 쓰던 도끼", 99, 0, 99999));
        }

        public void addShop(Item item)
        {
            shop.Add(item);
        }

        public Item Buy (Item item, Character player)
        {
            if(player.gold >= item.gold)
            {
                
                player.gold = player.gold - item.gold;
                return item;
            }
            else
            {
                return null;
            }
        }

        public int Sell(Item item)
        {
            return item.gold;
        }
    }
}