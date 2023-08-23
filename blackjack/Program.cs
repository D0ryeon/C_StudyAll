using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace blackjack
{
    //블랙잭 규칙


    //K, Q, J는 10점에 해당
    //A는 1혹은 11 어느쪽으로도 계산 가능
    //카지노에 따라 1이나 11중 하나로 고정하기도 함
    //기본적으로 처음에는 카드 두장을 지급

    //카드 드로우
    //


    //승리조건
    //카드를 더해서 21점을 먹으면 승리

    //패배 조건
    //21을 초과하는순간 버스트

    
    public enum Stamp {Heart,Diamond,Spade,Clover}
    public enum CardNum {Two=2,Three,Four,Five,Six,Seven,Eight,Nine,Ten,Jack,Queen,King,Ace};



    // 카드 한 장 !!!!!!!!!!!!!!!!!!!을 표현하는 클래스
    public class Card
    {
        public Stamp Stamp { get; set; }
        public CardNum CardNum { get; set; }

        public Card(Stamp stamp, CardNum cardNum)
        {
            Stamp = stamp;
            CardNum = cardNum;
        }

        // 카드의 블랙잭에서의 점수를 반환하는 메소드
        public int GetValue()
        {
            // 카드 점수 확인 10 이하는 모두 카드의 숫자만큼 점수를 부여함
            if((int)CardNum <=10)
            {
                return (int)CardNum;
            }
            // 11 12 13에 위치한 J Q K 는 10의 점수를 주므로 10점 리턴
            else if((int)CardNum <= 13) 
            {
                return 10;
            }
            //그외 14번에 위치한 Ace는 때에 따라 다르지만 보통 11점을 선호한다. 이 뒤에 18점 이후에는 1점만 주도록 변경될 것
            else
            {
                return 11;
            }
        }

        // 카드의 무늬와 숫자를 문자열로 반환하는 메소드
        // Object 클래스에 정의된 public함수인 ToString()을 Override해서 작성함
        public override string ToString()
        {
            return $"{CardNum} of {Stamp}";
        }           
        
    }

    // 덱을 표현하는 클래스
    public class Deck
    {
        // 덱에 있는 카드들
        private List<Card> cards;
   
        // 덱생성
        public Deck()
        {
            cards = new List<Card>();


            //foreach 함수로 Stamp의 밸류값을 나열함
            foreach(Stamp s in Enum.GetValues(typeof(Stamp)))
            {
                // Stamp의 밸류값 하나당 CardNum의 밸류를 나열
                foreach(CardNum c in Enum.GetValues(typeof(Stamp)))
                {
                    // 해당 스탬프 숫자 하나씩 Add()함수로 cards 리스트에 넣어줌
                    cards.Add(new Card(s,c));
                }
            }
            // 위에서 담아준 카드덱을 섞어줄 메소드를 호출
            Shuffle();
        }

        // 카드를 섞는 메소드
        public void Shuffle()
        {
            // 셔플해줄 랜덤 숫자를 정할 random 변수
            Random random = new Random();
            for(int i = 0; i < cards.Count; i++)
            {
                // 여기서 랜덤 변수를 i부터 시작하게 해서 같은 카드가 중첩되지 않도록 만듬
                int r = random.Next(i,cards.Count);
                Card t = cards[i];
                cards[i] = cards[r];
                cards[r] = t;                
            }
            
        }

        // 덱에 있는 카드 한 장을 뽑는 메소드
        public Card DrawCard()
        {
            // 카드 리스트중 맨 앞에 있는 한장 뽑음
            Card choice = cards[0];
            // 뽑은 카드는 덱에서 삭제
            cards.RemoveAt(0);
            return choice;
        }
    }

    // 플레이어의 패를 표현하는 클래스
    public class Hand
    {
        private List<Card> cards;

        public Hand()
        {
            cards = new List<Card>();
        }

        // 카드를 패에 추가하는 메소드
        public void AddCard(Card card)
        {
            cards.Add(card);         
        }

        // 패의 총점을 계산하는 메소드
        public int GetTotalValue()
        {
            int total = 0;
            int aceCount = 0;
            
            // 내 카드패 리스트를 나열
            foreach(Card card in cards)
            {
                // Ace는 조건에 따라 점수가 다르기 때문에 다로 뺌
                if(card.CardNum == CardNum.Ace)
                {
                    aceCount++;
                }
                total += card.GetValue();
            }

            // 에이스가 있고 총 점이 21점 넘을 때, 에이스를 1점으로 취급
            while (total > 21 && aceCount > 0)
            {
                total -= 10;
                aceCount--;
            }
            return total;
        }
    }

    // 플레이어를 표현하는 클래스
    public class Player
    {
        // 플레이어의 패
        public Hand Hand {  get; private set; }

        public Player()
        {
            Hand = new Hand();
        }


        // 카드를 뽑는 메소드
        public Card DrawCardFromDeck(Deck deck)
        {
            // DrawCard() : 덱에 있는 카드 한 장을 뽑는 메소드
            
            Card drawnCard = deck.DrawCard();
            Hand.AddCard(drawnCard);
            return drawnCard;
        }
    }

    // 딜러를 표현하는 클래스
    public class Dealer : Player
    {
        // 딜러는 총점이 17점 미만일 때 계속해서 카드를 뽑는다
        public void KeepDrawingCards(Deck deck)
        {
           
        }
    }

    // 블랙잭 게임을 표현하는 클래스
    public class Blackjack
    {


        public void PlayGame()
        {

        }   
    }

    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }




}