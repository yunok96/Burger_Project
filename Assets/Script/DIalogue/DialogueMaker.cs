﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueMaker : MonoBehaviour
{
    Dictionary<int, string[]> talkData;
    Dictionary<int, Sprite> portData;

    public Sprite[] portArr;//스프라이트 추가용

    void Awake()
    {
        talkData = new Dictionary<int, string[]>();//초기화
        portData = new Dictionary<int, Sprite>();
        GenerateData();
    }

    void GenerateData()//규칙. "텍스트 : 왼쪽 초상화 (0미출력) : 오른쪽 초상화 : 암전 효과 (0없음, 1왼쪽만 암전, 2오른쪽만 암전, 3양쪽 암전) : 0이면 효과없음, 1이면 카메라 흔들림(비우면 안됨)"  특수 규칙. "Event로 하면 조작 불가능인 상태로 대화창만 사라짐 :숫자 로 이벤트 설정"
    {
        talkData.Add(100, new string[] {
            "맑은 날씨, 오늘도 어제같은 나의 하루가 시작한다.:0:0:0:0",
            "저 출근했습니다! 오늘도 맑은 날씨!:0:10:0:0",
            "어, 왔구나.:26:10:2:0",
            "목소리 좀 낮추면 안 되겠니?:26:10:2:0",
            "네!! 알겠습니다!!!!!!:26:9:1:1",
            "낮추라니까…:26:9:2:0",
            "아무튼 오늘 안 좋은 소식하고 좋은 소식이 있다.:26:10:2:0",
            "뭐부터 듣고 싶-:26:10:2:0",
            "좋은 소식이요!!!!!!:26:9:1:1",
            "시끄럽다니까…:26:10:2:0",
            "좋은 소식이 뭐냐 하면,:26:10:2:0",
            "오늘부터 5일동안 내가 집안 사정 때문에,:26:10:2:0",
            "가게에 있지 못한다.:26:10:2:0",
            "네?? 그게 어떻게 좋은 소식이...:26:1:1:0",
            "나쁜 소식은,:26:1:2:0",
            "우측 문이 망가졌어.:26:1:2:0",
            "헉…:26:1:1:0",
            "전에 쓰던 수리 업체가 도산해서 1주일은 기다려야할 것 같다.:26:1:2:0",
            "저 혼자 너무 열악하네요.:26:1:1:0",
            "아무튼 돈은 2배로 줄게.:26:1:2:0",
            "평생 따르겠습니다.:26:5:1:0",
            "아무튼 이만 가 봐야해.:26:5:2:0",
            "고생하라고.:26:10:2:0",
            "Event:1"
        });

        talkData.Add(200, new string[] {
            "그러면 오늘은 나 혼자인가?:0:10:0:0",
            "혼자라면 2배를 일 해야겠네?:0:10:0:0",
            "그러면 평소보다 힘들겠어… 그러면…:0:10:0:0",
            "두!!:0:5:0:1",
            "배!!!:0:5:0:1",
            "더!!!!:0:5:0:1",
            "움직여야지!:0:5:0:0",
            "[W],[A],[S],[D]로 캐릭터를 이동할 수 있습니다. 캐릭터를 이동할 때 마다 활기 게이지가 증가합니다. 활기 게이지가 증가하면 소지할 수 있는 요리 수가 늘어납니다.:0:0:0:0",
            "Event:2"
        });

        talkData.Add(300, new string[] {
            "앗!:0:10:0:0",
            "첫 주문이 들어왔어. 확인하러 가보자!:0:10:0:0",
            "영업을 시작하면 실시간으로 주문이 들어옵니다. 주문은 좌측에 있는 카운터에 접수됩니다. 일정 시간이 지나면 주문이 사라지니 주의하세요:0:0:0:0",
            "Event:3"
        });

        talkData.Add(1, new string[] {
            "우리 가게의 창고다. 그런데...:0:0:0:0",
            "...여긴 점장님이 들어가지 말라고 하셨지?:0:6:0:0",
            "그냥 평범한 창고같은데...:0:1:0:0",
            "...왜일까?:0:1:0:0",
            "Event:0"
        });

        talkData.Add(2, new string[] {
            "...들어가지 말자.:0:1:0:0",
            "Event:0"
        });

        talkData.Add(3, new string[] {
            "들어가지마:0:11:0:0",
            "Event:0"
        });

        talkData.Add(4, new string[] {
            "빗자루네.:0:10:0:0",
            "가게 정리할때나 뭔가 치워야 할때는 쓰겠지만...:0:12:0:0",
            "지금은 필요없겠지?:0:10:0:0",
            "Event:0"
        });

        talkData.Add(5, new string[] {
            "음...:0:12:0:0",
            "아무리 봐도 청소용 말곤 별 쓸모는 없어보이는데...:0:6:0:0",
            "아참! 손이 안 닿는 곳에 들어간 걸 빼낼 때에도 쓰지!:0:10:0:0",
            "Event:0"
        });

        talkData.Add(6, new string[] {
            "그 외엔 뭐가 있을까?:0:12:0:0",
            "청소용...길다...딱딱하다...:0:12:0:0",
            "봉...? 아니, 무기...?:0:6:0:0",
            "어...확실히 이걸로 맞으면 아프겠지?:0:6:0:0",
            "으으...상상해버렸어...:0:1:0:0",
            "...그래도 호신용으로는 쓸 만할 것 같아.:0:12:0:0",
            "Event:0"
        });

        talkData.Add(7, new string[] {
            "근데 이 빗자루 디자인이 조금 특이하네.:0:12:0:0",
            "튼튼해 보인달까...투박하달까...이런 패스트푸드점에서 쓰일 만한 건 아닌 것 같은데.:0:12:0:0",
            "어...? ...어디서 봤던것 같은데......:0:6:0:0",
            "아!!!:0:4:0:1",
            "군인들이 눈 치우는 사진이다!:0:5:0:0",
            "Event:0"
        });

        talkData.Add(8, new string[] {
            "...그나저나 이 빗자루는 왜 여기 있는 걸까?:0:6:0:0",
            "이런 통로 같은 곳에 있으면 걸려서 넘어질 것 같은데. 그리고 손님이 보기에도 조금 안 좋아 보이고.:0:6:0:0",
            "보통은 창고 같은데에 넣어둘 텐데 말야...:0:6:0:0",
            "근데 점장님이 창고에는 들어가지 말라고 하셨으니깐...그렇다고 청소를 안 할 수는 없으니까 어쩔 수 없이 꺼내놓은 걸까?:0:1:0:0",
            "음...:0:1:0:0",
            "...전혀 모르겠어.:0:1:0:0",
            "Event:0"
        });

        talkData.Add(9, new string[] {
            "...봐도 이젠 아무것도 떠오르지 않아. 일에 집중하자!:0:10:0:0",
            "Event:0"
        });


        talkData.Add(10, new string[] {
            "이건 튀김기인데?:0:6:0:0",
            "음...:0:12:0:0",
            "나중에 할까?:0:10:0:0",
            "Event:0"
        });

        talkData.Add(20, new string[] {
            "아이스크림 기계네?:0:6:0:0",
            "음...:0:12:0:0",
            "나중에 할까?:0:10:0:0",
            "Event:0"
        });

        talkData.Add(30, new string[] {
            "콜라 디스펜서야...:0:6:0:0",
            "음...:0:12:0:0",
            "나중에 할까?:0:10:0:0",
            "Event:0"
        });
        talkData.Add(31, new string[] {
            "...보고 있으니깐 왠지 목이 마른데...:0:6:0:0",
            "...아냐아냐!:0:12:0:0",
            "하던 일이 있으니 나중에 하자!:0:10:0:0",
            "Event:0"
        });
        talkData.Add(32, new string[] {
            "...조금만 마실까?:0:6:0:0",
            "목 축이는 정도는 괜찮겠지?:0:10:0:0",
            "그럼 조금만...:0:18:0:0",
            "...쪼르르륵......:0:0:0:0",
            "......꿀꺽꿀꺽...:0:0:0:0",
            "......:0:0:0:0",
            "...............:0:0:0:0",
            "........................:0:13:0:0",
            "...스윽,슥.:0:0:0:0",
            "............:0:11:0:0",
            "응! 역시 맛있어!:0:9:0:0",
            "그럼 다시 일에 집중하자!:0:10:0:0",
            "Event:0"
        });
        talkData.Add(33, new string[] {
            "이젠 괜찮아. 일에 집중하자?:0:10:0:0",
            "Event:0"
        });

        talkData.Add(400, new string[] {
            "주문은 햄버거. 그러면 오늘 첫 요리를 해볼까?:0:10:0:0",
            "요리는 [햄버거], [감자튀김], [콜라], [아이스크림]이 존재합니다. 각 요리는 획득할 수 있는 장소가 정해져 있습니다.:0:0:0:0",
            "조리를 성공적으로 마치면 요리를 얻을 수 있습니다. 소지할 수 있는 요리의 수량은 한도가 있습니다!:0:0:0:0",
            "Event:4"
        });

        talkData.Add(40, new string[] {
            "우왓!!!!!!:0:4:0:1",
            "바닥에 떨어져버렸어!!!!:0:4:0:1",
            "우으...:0:1:0:0",
            "다시 만들어야지...:0:1:0:0",
            "조리에 실패하면 요리를 얻을 수 없습니다... 집중해서 다시 해보세요.:0:0:0:0",
            "Event:0"
        });
        talkData.Add(50, new string[] {
            "응?:0:6:0:0",
            "햄버거?:0:6:0:0",
            "음...:0:12:0:0",
            "아직 할게 남아있으니까 나중에 하자.:0:10:0:0",
            "Event:0"
        });

        talkData.Add(500, new string[] {
            "햄버거 완성~!:0:9:0:0",
            "오늘도 너무 맛있어 보이는 걸…:0:18:0:0",
            "특히 이 패티, 날 유혹하는 거 같은데?:0:18:0:0",
            "역시 난 고기 없음 못 사나 봐...:0:18:0:0",
            "획득한 요리는 카운터에 전달할 수 있습니다.:0:0:0:0",
            "Event:5"
        });

        talkData.Add(600, new string[] {
            "주문하신 햄버거 나왔습니다~!:22:9:1:0",
            "감사합니다.:22:9:2:0",
            "언니, 오늘도 활기차시네요.:22:9:2:0",
            "Event:6"
        });

        talkData.Add(700, new string[] {
            "벌써 한 건 해결했어. 오늘도 순조로운 걸?:0:10:0:0",
            "Event:7"
        });

        talkData.Add(800, new string[] {
            "...우으으욱, 으으......:0:0:0:0",
            "꺅!:4:0:0:1",
            "고장 난 우측 문에서 주정뱅이들이 스폰됩니다. 주정뱅이들은 플레이어의 진로를 방해할 것입니다!:0:0:0:0",
            "저분들 말이 통하지 않는 것 같은데... 어떻게 하지?:6:0:0:0",
            "으음...:1:0:0:0",
            "...빗자루로 정중히 부탁해 볼까?:1:0:0:0",
            "Event:8"
        });
        talkData.Add(900, new string[] {
            "인벤토리에 있는 빗자루를 사용하면 주정뱅이를 내보낼 수 있습니다. 아이템은 [Q],[E]키를 통해 선택할 수 있으며 [SPACE]키를 누르면 사용됩니다.:0:0:0:0",
            "Event:0"
        });
        talkData.Add(1000, new string[] {
            "휴... 겨우 돌려 보냈어.:0:6:0:0",
            "오늘은 정말 바빠질 것 같은데?:0:7:0:0",
            "...그런데 뭔가 단 걸 먹고 싶은데...:0:6:0:0",
            "응?:0:6:0:0",
            "뭐지 저게?:0:10:0:0",
            "메모??:0:10:0:0",
            "Event:9"
        });
        talkData.Add(1100, new string[] {
            "'오늘 혼자 일하느라 고생이 많구나.:0:10:0:0",
            "내가 주방 곳곳에 간식을 많이 뿌려 뒀으니:0:12:0:0",
            "힘들 때 마다 먹으면서 하렴.:0:12:0:0",
            "‘멋진’ 점장이':0:12:0:0",
            "점장님이 날 생각해 주시다니...:0:9:0:0",
            "...해가 서쪽에서 뜨겠다.:0:7:0:0",
            "평소에도 이렇게 해주시면 얼마나 좋을까...:0:1:0:0",
            "누군가가 남겨놓은 간식들을 획득할 수 있습니다. 간식들엔 고유 기능이 있습니다. 위기의 순간에 적절하게 사용하세요.:0:0:0:0",
            "좋아, 그러면 오늘도 하루를 시작해볼까?:0:10:0:0",
            "영업이 끝나기 전에 주문을 3개를 놓친다면 게임 오버가 됩니다.영업을 마칠 때 까지 주문을 놓치지 않고 전달하세요!:0:0:0:0",
            "Event:10"
        });
        talkData.Add(1150, new string[] {
            "끝났다!!!:0:9:0:0",
            "혼자 해도 문제 없잖아~.:0:10:0:0",
            "그래도 점장님이 주신 간식들이 큰 힘이 됐어.:0:10:0:0",
            "내일도 오늘처럼 완벽하게:0:10:0:0",
            "아자 아자 파이팅!:0:5:0:0",
            "Event:0"
        });
        talkData.Add(1200, new string[] {
            "끝났다!!!!:0:9:0:0",
            "힘들기는 하지만 할만 했어!:0:10:0:0",
            "뭔가 빼먹은 것 같은데...:0:6:0:0",
            "뭐 별 문제 있겠어?:0:9:0:0",
            "내일도 오늘처럼 완벽하게:0:10:0:0",
            "아자 아자 파이팅!:0:9:0:0",
            "Event:0"
        });
        talkData.Add(1201, new string[] {
            "...:0:25:0:0",
            "오늘도 즐거웠어, 자기?:0:25:0:0",
            "그래.:0:25:0:0",
            "쉬고 있어.:0:25:0:0",
            "우리의 식사가 시작되려면:0:25:0:0",
            "아직 한참 남았으니까...:0:25:0:0",
            "후후후...:0:25:0:0",
            "이대로는 진실을 볼 수 없다.:0:0:0:0",
            "-Ending C:0:0:0:0",
            "Event:1"
        });

        talkData.Add(2000, new string[] {
            "저 출근했습니다! 오늘도 맑은...:0:10:0:0",
            "읍!!!:0:4:0:1",
            "...어디서 퀴퀴한 냄새가 나는데...?:0:6:0:0",
            "어제 주정뱅이들이 토하고 갔나? 그런 냄새는 아닌 것 같긴 한데...:0:6:0:0",
            "이따 알아보자! 일단 일부터!:0:5:0:0",
            "Event:1"
        });

        talkData.Add(2100, new string[] {//총줍
            "......:0:4:0:1",
            "......:0:4:0:0",
            "이거...진짜야...?:0:4:0:0",
            "...아마 장난감 총일거야. 그치?:0:4:0:0",
            "......:0:4:0:0",
            "아까 그 사람 거 같은데.:0:1:0:0",
            "오해할 수 있으니까 일단 갖고 있다가:0:1:0:0",
            "영업 끝나면 경찰서에 맡겨야지.:0:1:0:0"
        });

        talkData.Add(2200, new string[] {//죽어라 주정뱅이!
            "진짜였어...?:0:4:0:0",
            "......:0:4:0:0",
            "하긴,:0:1:0:0",
            "이렇게 시끄러운 주방에서 한 명 죽었다고 해서:0:1:0:0",
            "신경 쓸 사람 없잖아?:0:1:0:0",
            "그치?:0:9:0:0",
            "이왕 썼으니까 자주 활용해주자.:0:9:0:0"
        });

        talkData.Add(2300, new string[] {//A루트
            "오늘도 끝~!!!:0:9:0:0",
            "오늘도 어제만큼 퍼펙트했어.:0:10:0:0",
            "그런데 왜 아직도 퀴퀴한 냄새가 나는 것 같지?:0:6:0:0",
            "어디서 나는지 알아봐야겠어.:0:6:0:0"
        });
        talkData.Add(2301, new string[] {//피웅덩이 조사
            "이건...피인가?:0:4:0:0",
            "말라붙은 걸 보면 꽤 시간이 흐른 것 같은데.:0:6:0:0",
            "왜 이런 게 창고 아래에 있지? 어제는 분명 없었는데...:0:6:0:0",
            "창고 안에 있는 고기가 녹은걸까?:0:6:0:0",
            "점장님이 창고는 들어가지 말라 하셨으니.:0:6:0:0",
            "닦아만 놓자:0:6:0:0",
            "...점장님은 왜 창고에 들어가지 말라 한 걸까...?:0:6:0:0",
            "...예전부터 생각했지만 모르겠어.:0:6:0:0",
            "빨리 청소하고 빨리 쉬자.:0:6:0:0",
            "Event:1"//페이드 아웃과 BGM 정지.
        });
        talkData.Add(2302, new string[] {//페이드 아웃 이후
            "......:0:0:0:0",
            "예전...?:0:0:0:0",
            "그러고 보니 나는...:0:0:0:0",
            "여기서 일한 지 얼마나 됐지...?:0:0:0:0",
            "......:0:0:0:0",
            "Event:2"//A루트 데이3로
        });
        talkData.Add(2303, new string[] {//A루트 데이3
            //암전 - 페이드인
            "저 출근했…:0:10:0:0",
            "읍!!!!!!:0:4:0:0",
            "냄새가 더 심해졌어.:0:4:0:0",
            "분명 어제 탈취제도 엄청 뿌렸는데 이렇게 냄새가…:0:4:0:0",
            "게다가… 핏자국이 더 심해졌잖아.:0:4:0:0",
            "어제 밤에 고장 난 문으로 누가 주방에 들어온 걸까?:0:6:0:0",
            "그래도 사라진 물건은 없어 보여.:0:6:0:0",
            "그냥 오늘 점장님께 전화 드리고 문을 고쳐야겠어.:0:6:0:0",
            "… 좀 무서운가?:0:1:0:0",
            "아니야! 별거 아닌 걸!:0:7:0:0",
            "실례합니다. 아직 주문 안 받나요?:22:7:2:0",
            "네네 가요!:22:7:1:0",
            "평소랑 다를 거 없는 날이야.:22:7:1:0",
            "허튼 생각 말고 일에 집중하자!:22:10:1:0"
            //데이 시작
        });
        talkData.Add(2304, new string[] {//데이3 끝
            "오늘도 끝! ...:0:10:0:0",
            "… 주변에 이건:0:6:0:0",
            "뭐지:0:6:0:0",
            "주방 가운데에 고기가 있나?:0:6:0:0",
            "그렇지 않고서야 이렇게:0:6:0:0",
            "… 피가 …:0:4:0:0",
            "아니야…:0:4:0:0",
            //서랍에서 머리 나오는 이벤트
        });
        talkData.Add(2305, new string[] {
            //이벤트 후
            "으…:0:2:0:0",
            "우으으으…:0:2:0:0"
            //이벤트 시작 (암전, 브금 종료)
        });
        talkData.Add(2306, new string[] {
            //이벤트 후
            "꺄아아아아아악!!!!!:0:2:0:0"
            //데이 끝
        });
        talkData.Add(2307, new string[] {//데이4
            //암전 - 페이드인
            "도대체 어제는 무슨 일이 있었지?:0:15:0:0",
            "아무 일도 없었지?:0:15:0:0",
            "…아냐:0:15:0:0",
            "어젠 무서워서 도망쳤지만:0:15:0:0",
            "바구니에 있던 것은 분명:0:15:0:0",
            "사람 머리였어.:0:15:0:0",
            "그러고 보니 나는 왜 여기에 온거지?:0:15:0:0",
            "오늘도 어제와 같을 수는 없을 건데…:0:15:0:0",
            "…아무래도 안 되겠어.:0:12:0:0",
            "창고를 확인하자.:0:12:0:0",
            "처음으로 피가 나온 곳도 저기야.:0:12:0:0",
            "점장님은 창고에 들어가지 말라고 하셨지만 뭔가가 저기 숨겨져있어.:0:12:0:0",
            "창고에 들어가자.:0:12:0:0"
            //이벤트 시작
        });
        talkData.Add(2308, new string[] {
            //이벤트 후
            "창고 안에 이런 넓은 공간이?:0:6:0:0",
            "믿기지 않아. 마치 다른 세상 같잖아:0:6:0:0",
            "조금 더 올라가 보자.:0:12:0:0"
            //이벤트
        });
        talkData.Add(2309, new string[] {
            //이벤트 후
            "퀴퀴한 냄새가 점점 역해지고 있어.:0:6:0:0",
            "도대체 여기는 뭐하는 곳이지?:0:6:0:0"
            //이벤트
        });
        talkData.Add(2310, new string[] {
            //이벤트 후
            "으…:0:2:0:0"
            //이벤트
        });
        talkData.Add(2311, new string[] {
            //이벤트 후
            "윽… 머리가 아파…:0:6:0:0",
            "뭘 하고 있었더라…?:0:6:0:0",
            "아… 영업 시작 시간인가?:0:6:0:0",
            "…어찌 됐든 영업 개시하자.:0:6:0:0"
            //데이 시작
        });
        talkData.Add(2312, new string[] {
            //데이 클리어
            "오늘도 끝났다…:0:12:0:0",
            "… 뭔가 이상해.:0:12:0:0",
            "아까 무언가 했던 것 같은데.:0:12:0:0",
            "기억이 나질 않아.:0:12:0:0",
            "아니 여태까지 기억하지 못하다가.:0:12:0:0",
            "지금에야 눈치채고 있는건가?:0:12:0:0",
            ":0:0:0:1",//0.3프레임간 흔들림
            "윽!!!!!:0:4:0:0"
            //이벤트
        });
        talkData.Add(2313, new string[] {
            //이벤트 후
            "저 출근했습니다! 오늘도 맑은 날씨!:0:10:0:0"
            //이벤트 시작
        });
        talkData.Add(2314, new string[] {
            //이벤트 후
            "저 출근했습니다! 오늘은 좀 더운 날씨!:0:10:0:0"
            //이벤트 시작
        });
        talkData.Add(2315, new string[] {
            //이벤트 후
            "저 출근했습니다! 오늘도:0:10:0:0"
            //이벤트 시작
        });
        talkData.Add(2316, new string[] {
            //이벤트 후
            "오늘도:0:10:0:0"
            //이벤트 시작
        });
        talkData.Add(2317, new string[] {
            //이벤트 후
            "오늘도:0:10:0:0"
            //이벤트 시작
        });
        talkData.Add(2318, new string[] { //시공 조아 먹여조
            //이벤트 후
            "피:0:20:0:0",
            "좋아:0:20:0:0",
            "먹여줘:0:20:0:0"
            //이벤트 시작
        });
        talkData.Add(2319, new string[] {
            //이벤트 후
            "방금 그건?:0:15:0:0",
            "설마 내가 잃은 기억?:0:15:0:0",
            "난… 난 도대체:0:15:0:0",
            ":0:0:0:1",//화면흔들림
            "윽, 머… 머리가…:0:15:0:0"
            //이벤트 시작 -> 데이 종료
        });
        talkData.Add(2320, new string[] {
            //데이시작
            "…:0:15:0:0",
            "결국 또 여기네:0:15:0:0",
            "뭘 하고 있었지…?:0:15:0:0",
            "방금 전 기억조차 내겐 없어:0:15:0:0",
            "…지옥이 있다면 아마 여기겠지.:0:15:0:0",
            "…:0:15:0:0",
            "하지만 뭔가 달라지고 있어:0:15:0:0",
            "보이지 않던 이 곳의 추악함이 보이기 시작하고:0:15:0:0",
            "기억이… 조금씩이지만… 되돌아오고 있어…:0:15:0:0",
            "…:0:15:0:0",
            "도대체 나는 무슨 짓을 저지른거지?:0:15:0:0",
            "나는 무엇이지?:0:15:0:0",
            "…:0:15:0:0",
            "응?:0:15:0:0",
            "또 포스트 잇이?:0:15:0:0",
            "점장님이 왔을 리는 없는데…:0:15:0:0"
            //이벤트 시작
        });
        talkData.Add(2321, new string[] {
            //이벤트 후
            "“이제 약효가 듣나 보군.:0:15:0:0",
            "“그 날 이후 이 순간만을 기다렸다.”:0:15:0:0",
            "“오늘 너를 구하러 가겠다”:0:15:0:0",
            "…:0:15:0:0",
            "도대체 누구지?:0:15:0:0",
            "…:0:15:0:0",
            "궁금하지 않아.:0:15:0:0",
            "이것도… 그냥 잊어버리자.:0:15:0:0"
            //데이시작
        });
        talkData.Add(2322, new string[] {
            //데이 클리어
            "무슨 소리지?:0:15:0:0"
            //이벤트 시작
        });
        talkData.Add(2323, new string[] {
            //이벤트 후
            "…? 어서 오세…:0:15:0:0"
            //이벤트 시작
        });
        talkData.Add(2324, new string[] {
            //이벤트 후
            "날 알아 보겠나?:28:15:2:0",
            "네?:28:16:1:0",
            "부엌에 남겨 놓은 포스트 잇.:28:16:2:0",
            "내가 남긴 거다.:28:16:2:0",
            "그 때는 무책임하게 도망가서 미안했다.:28:16:2:0",
            "이제라도 이 마굴에서 너를 해방시켜주지.:28:16:2:0",
            "갑자기 그렇게 말하셔도…:28:16:1:0",
            "기억을 못하는건가?:28:16:2:0",
            "나는 퇴마사다.:28:16:2:0",
            "너의 몸엔 지금 악신이 깃들어 있다.:28:16:2:0",
            "악신은 형체를 지니고 있지 않아.:28:16:2:0",
            "하지만 끝 없는 피의 갈증 때문에:28:16:2:0",
            "실체를 얻고 싶어한다.:28:16:2:0",
            "… 그렇게 선택된 것이 너인 것이지.:28:16:2:0",
            "이 가게는 그 악신을 신봉하는 무리들이 벌이는:28:16:2:0",
            "살육의 장이다.:28:16:2:0",
            "…:28:15:1:0",
            "악신의 힘을 약화 시키기 위해:28:15:2:0",
            "성스러운 약을 탄 [간식]을 너에게 전달해왔다.:28:15:2:0",
            "그 과정에서 많은 희생이 있었지만:28:15:2:0",
            "덕분에 지금 그 악신이 많이 쇠약해졌다.:28:15:2:0",
            "이 장소를 구제할 수는 없겠지만:28:15:2:0",
            "‘무고한’ 너는 탈출시킬 수 있어.:28:15:2:0",
            "기회는 지금 뿐이야.:28:15:2:0",
            "일상을 찾고 싶다면…:28:15:2:0",
            "내 손을 잡아.:28:15:2:0",
            "곧장 여기를 탈출한다.:28:15:2:0"
            //이벤트 시작
        });
        talkData.Add(2325, new string[] {
            //이벤트 후
            "따라 갈게요.:28:15:1:0",
            "잘 생각했다.:28:15:2:0",
            "제발… 이 악몽을 끝내 주세요.:28:17:1:0",
            "눈을 감고 내 손을 놓지 마라.:28:17:2:0",
            "보기 좋지 못할 광경이 벌어질거니:28:17:2:0"
            //이벤트 시작
        });
        talkData.Add(2326, new string[] {
            //이벤트 후
            "후후후후:25:0:0:0",
            "그렇게 피가 싫었어?:25:0:0:0",
            "누구세요?:25:12:1:0",
            "이제 나를 모른 척 하는 거야?:25:12:2:0",
            "저는 당신을 몰라요:25:12:1:0",
            "당신이… 설마 그 악신?:25:12:1:0",
            "악신이라니, 너무 서운하게 만드는 걸.:25:12:2:0",
            "우리가 처음 만났을 때는 분명:25:12:2:0",
            "너가 나를 꼬셨잖아:25:12:2:0",
            "뭐… 라고요?:25:4:1:0",
            "피에 대한 호기심에 미쳐서:25:4:2:0",
            "먼저 손을 내밀었던 것은:25:4:2:0",
            "너였지.:25:4:2:0",
            "너는 내게 몸과 영혼을 맡겼고:25:4:2:0",
            "우리는 매일같이 행복의 만찬을 누렸어.:25:4:2:0",
            "일 년 전에도, 한 달 전에도… 바로 어제도.:25:4:2:0",
            "전혀 기억하지 못하는 거야?:25:4:2:0",
            "그런 기억 없어요…:25:4:1:0",
            "…그런 것은 내가 아니야!!!!:25:8:1:0",
            "아니라고 부정해도 소용 없어…:25:8:2:0",
            "너는 ‘제물’ 먹었다고:25:8:2:0",
            "식욕을 주체할 수 없지 않아?:25:8:2:0",
            "아니라고!!!!:25:8:1:0",
            "그만 나를 놓아줘!!!!!:25:8:1:0",
            "…:23:8:2:0",
            "돌아오지 않는 건가…:23:8:2:0",
            "그 쥐새끼 녀석이 너를 망가뜨렸구나:23:8:2:0",
            "난 여전히 너가 좋은데…:23:8:2:0",
            "나한테 말 걸지 마:23:8:1:0",
            "나는 이 지옥을 벗어날 거야:23:8:1:0",
            "제발 내게서 떨어지라고!!!!:23:8:1:0",
            "…:23:8:2:0",
            "멋대로 나를 끌어들이고서는:23:8:2:0",
            "이제 와서 내게 멀어지려 하다니:23:8:2:0",
            "….:23:8:2:0",
            "알겠어:25:8:2:0",
            "너를 돌려 놓을 수는 없는 거네.:25:8:2:0",
            "…하지만 너를 포기 할 수도 없지:25:8:2:0",
            "갑자기 무슨 소리를 하는거야?:25:4:1:0",
            "너를 먹을거야:25:4:2:0",
            "그러면 내가 너를 좀 더 이해 할 수 있겠지:25:4:2:0",
            "먹는다니 무슨소리야:25:4:1:0",
            "그만둬!!!!!!:25:8:1:0",
            "걱정하지마. 고통스럽지 않아.:25:8:2:0",
            "하찮은 미물로 사는 것 보다:25:8:2:0",
            "신의 일부가 되어 사는것은:25:8:2:0"
            //이벤트 시작
        });
        talkData.Add(2327, new string[] {
            //이벤트 후
            //"???: 행복. (cg:웃음 애니메이션)", //웃음 애니메이션
            //"???: 이리와 (cg:웃음 애니메이션", //웃음 애니메이션
            //"???: 우리, 하나가 되자. (cg:웃음 애니메이션", //웃음 애니메이션
            "안돼…::2:1:0",
            //"???: 자, 이제 (cg:웃음 애니메이션", //웃음 애니메이션
            "싫어…::2:1:0",
            //"???: 하나로. (cg:웃음 애니메이션", //웃음 애니메이션
            "싫어 !!!!!!!!!!!!!!!!!::3:1:0"
            //이벤트 시작
        });
        talkData.Add(2328, new string[] {
            //이벤트 후
            "무슨 일이야?:28:0:0:0",
            "…:28:21:1:0",
            "이런…:27:21:2:0",
            "이제 영원히 함께야:27:21:1:0",
            "자기:27:19:1:0"
            //엔딩
        });




        //------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------
        ////----------------------------------------B루트-------------------------------------
        //------------------------------------------------------------------------------------
        //------------------------------------------------------------------------------------
        talkData.Add(2400, new string[] {
            "오늘도 끝~!!!:0:9:0:0",
            "오늘도 어제만큼 퍼펙트했어.:0:10:0:0",
            "‘손님’이 주고 가신 ‘도구’ 덕분에:0:10:0:0",
            "일도 더 편하고 재밌었지.:0:10:0:0",
            "아무튼 내일도 오늘처럼 완벽하게!:0:10:0:0",
            "아자 아자!:0:9:0:0",
            "Event:1"//페이드 아웃
        });
        //재준 작업 (루트B 데이3부터) 이벤트 없음 id 3000부터 시작
        talkData.Add(3000, new string[] {
            //암전, 페이드인시작
            "저 출근했습니다! 오늘은 더더욱 맑은 날씨!:0:10:0:0",
            "주방에서도 향긋한 냄새가 나!:0:10:0:0",
            "요즘 일이 왜 이렇게 즐거울까?:0:9:0:0",
            "실례합니다. 아직 주문 안 받나요?:22:9:2:0",
            "네네 가요!:22:9:1:0",
            "평소보다 좋은 날이야:0:10:0:0",
            "오늘도 ‘일’에 집중하자!:0:5:0:0"
            //데이3 시작
        });
        talkData.Add(3001, new string[] {
            //데이3 클리어
            "오늘도 끝!:0:9:0:0",
            "점장님 없으니까 더 잘되는 거 같네:0:10:0:0",
            "꼬르륵:0:0:0:0",//나레이션
            "앗:0:6:0:0",
            "일을 열심히 하니까:0:18:0:0",
            "배가 너무 고픈걸:0:18:0:0",
            "주방에 먹을 것 좀 없을까?:0:18:0:0",
            "점장님이 주신 간식으로는 부족해:0:18:0:0",
            //이벤트 삽입 = 플레이어가 서랍까지 가서 서랍을 열면 사람머리 등장
        });
        talkData.Add(3002, new string[] {
            //서랍 사람머리 이벤트 후
            "…:0:6:0:0",
            "점장님도 참.:0:1:0:0",
            "이런 곳에 고기를 두고 가다니:0:1:0:0",
            "정신머리가 없으시단 말이야.:0:1:0:0",
            "고기가 상하기 전에 그러면:0:10:0:0",
            "잘 먹겠습니다.:0:33:0:0"
            //페이드아웃, 데이종료
        });
        talkData.Add(3003, new string[] {
            //데이49
            //암전 -> 페이드인
            "저 출근했습니다! 오늘은 더더욱 맑은 날씨!:0:10:0:0",
            "… 그래 아무도 없지:0:1:0:0",
            "점장님은 왜 아직도 오시지 않는걸까?:0:10:0:0",
            "그보다 오늘 영업 시작하기도 전에:0:10:0:0",
            "배가 너무 고픈걸:0:10:0:0",
            "그럼 손님들 올 때까지 시간이 있으니:0:10:0:0",
            "‘식사’를 할까:0:9:0:0",
            "매일 하던 것처럼:0:10:0:0"
            //이벤트 삽입
        });
        talkData.Add(3004, new string[] {
            //이벤트 후
            "후아:0:35:0:0",// (cg:피범벅)
            "잘먹었다:0:35:0:0"
            //이벤트 삽입
        });
        talkData.Add(3005, new string[] {
            //이벤트 후
            "그럼, 오늘도 시작해볼까:0:11:0:0"
            //데이 시작
        });
        talkData.Add(3006, new string[] {
            //데이49 클리어
            "오늘도 끝났다!:0:9:0:0",
            "창고로 가서 고기가 잘 있나 확인해 볼까?:0:9:0:0"
            //이벤트 삽입
        });
        talkData.Add(3007, new string[] {
            //이벤트 후
            "어떤 버러지가 시간 분별 못하고 처들어온거지?:0:11:0:0"
            //이벤트 삽입
        });
        talkData.Add(3008, new string[] {
            //이벤트 후
            "이 파리 새끼들은 어디서 기어 들어오는거지?:0:11:0:0",
            "까불었으면 벌을 받아야지?:0:11:0:0",
            "그럼:0:11:0:0",
            "만찬을 즐겨볼까?:0:11:0:0"
            //이벤트 삽입
        });
        talkData.Add(3009, new string[] {
            //이벤트 후
            "…:0:0:0:0", //???가 말하는 중. CG출력 없다고 함.
            "아아…:0:0:0:0",
            "이렇게 훌륭하다니…:0:0:0:0",
            "후후후…:0:0:0:0",
            "시작의 끝이 다가온다.:0:0:0:0"//나레이션 대사.
            //데이 종료
        });
        talkData.Add(3010, new string[] {
            //데이??? 맵 피범벅, 버거걸 피범벅_피폐
            //암전 -> 페이드인
            "…:0:20:0:0", // (cg: 갈구)
            "…:0:20:0:0",
            "…:0:20:0:0",
            "…:0:20:0:0"
            //데이 시작
        });
        talkData.Add(3011, new string[] {
            //데이??? 클리어
            //아무 대사 없이 이벤트로 시작
        });
        talkData.Add(3012, new string[] {
            //이벤트 후
            "…?:0:20:0:0"
            //이벤트 시작
        });
        talkData.Add(3013, new string[] {
            //이벤트 후
            "… 누구세요?:0:20:0:0",
            "도대체 어떻게 여기를?:0:20:0:0",
            "여기가 그야 말로 생지옥…:28:20:2:0",
            "…이 악마자식:27:20:2:0",
            "악마?:27:20:1:0",
            "누구한테 하시는 말씀인지…:27:20:1:0",
            "여자를 풀어줘:27:20:2:0",
            "도통 무슨 이야기인지 이해가 되질 않는데.:27:20:1:0",
            "시치미 때지 마라!!!:31:20:2:0",
            "난 여자의 어머니의 의뢰를 받고 왔다.:28:20:2:0",
            "이 역겨운 현장은 참고 넘어가기 어렵지만:28:20:2:0",
            "여자의 몸에서 네가 나가준다면:28:20:2:0",
            "난 더이상 여기에 개입하지 않겠다:28:20:2:0",
            "저는…:28:20:1:0",
            "그냥…:28:20:1:0",
            "평범한 사람인데…:0:0:0:0" //시나리오에 cg가 안들어가 잇음. 의도?
            //이벤트 시작
        });
        talkData.Add(3014, new string[] {
            //이벤트 후
            "좋.은. 취.향.을.:28:34:1:0",
            "가졌을 뿐이야.:28:34:1:0",
            "…:29:34:2:0",
            "…:29:34:2:0",
            "지독하군:29:34:2:0",
            "그 얘기가 진짜라면:29:34:2:0",
            "여자의 어머니에게는 미안하지만:29:34:2:0"
            //이벤트 시작
        });
        talkData.Add(3015, new string[] {
            //이벤트 후
            "죽어줘야겠어:29:34:2:0",
            "너 같은 쓰레기를 살려둘 수는 없지:29:34:2:0"
            //이벤트 시작
        });
        talkData.Add(3016, new string[] {
            //이벤트 후
            "여태까지 많은 사람들의 피를 마셔왔다면:0:0:0:0", //???대사. 시나리오에 cg없는 부분
            "이제 너가 그 피를 다 토해내야 하네:0:0:0:0",
            "불쌍하고 가여워라:0:0:0:0",
            "후후후:0:0:0:0", //???대사 여기까지
            "…누구냐…:0:14:0:0", //14번 피폐1
            "식성이 특이한 신이라고 해두지.:25:14:2:0",
            "…원래 너는 지금까지 살아있을 수 없는 존재지.:25:14:2:0",
            "…?:25:14:1:0",
            "너는 원래 내가 만든 환각을 보면서:25:14:2:0",
            "미쳐서 스스로 숨을 끊었어야 했다.:25:14:2:0",
            "하지만 너는 내 예상을 벗어나더군.:25:14:2:0",
            "전혀 미치지 않고 맨정신으로 피에 미치고 흥분했지.:25:14:2:0",
            "이건 이 나조차 상상하지 못한거야…:25:14:2:0",
            "덕분에 아주 재밌었지…:25:14:2:0",
            "주인공: …:25:14:1:0",
            "나를 즐겁게 해준 보답으로:25:14:2:0",
            "거래를 제안하지.:25:14:2:0",
            "내 피를 마셔라.:25:14:2:0",
            "너를 내 권속으로 만들어주지.:25:14:2:0",
            "그러면 매일 피의 축제를 열고:25:14:2:0",
            "영원한 왕국 속에 살게 해주겠다…:25:14:2:0",
            "어때…:25:14:2:0",
            "영원한 안식을 택하겠어?:25:14:2:0",
            "아니면… 선택해라.:25:14:2:0",
            "기대가 아주 크다고…:25:14:2:0",
            "후후후:25:14:2:0"
            //선택지 이벤트
        });
        talkData.Add(3017, new string[] {
            //이벤트 후
            "….:25:14:1:0",
            "나를…:25:14:1:0",
            "내게도 피를 계속 먹여줘:25:14:1:0",
            "부탁이야…:25:33:1:0",
            "후후후…:25:33:2:0",
            "완전히 미쳐버렸네:24:33:2:0",
            "좋아:24:33:2:0",
            "내 권속으로 만들어주지:24:33:2:0",
            "다만 낮에는 네 기억을 지워 둘게.:24:33:2:0",
            "한낱 인간이 신을 감당하면 너라도 금방 망가질테니…:24:33:2:0",
            "무엇이든 좋아:24:33:1:0",
            "부디…:24:33:1:0",
            "그래, 그렇다면:24:33:2:0",
            //"마셔라…(cg:웃음애니메이션)", //애니메이션 처리. 마셔라 헬스크림
            //"아아… (cg:광기_피범벅애니메이션)" //애니메이션 처리
            //이벤트 시작
        });
        talkData.Add(3018, new string[] {
            //이벤트 후
            "뭣…?:30:0:0:0",
            "죽지 않았잖아…?:30:0:0:0",
            "후후후…:30:21:1:0",
            "정말로… 악신이었던 거냐…???? ?:30:21:0:0",
            "어떻게 생각하던 자유야…:30:21:1:0",
            "오늘은 좋은 일이 있으니 살려주지.:30:21:1:0",
            "으으으…:30:21:0:0",
            "… 반드시 구해줄게:30:21:0:0",
            "조금만 버텨줘…:30:21:0:0"
            //이벤트 시작
        });
        talkData.Add(3019, new string[] {
            //이벤트 후
            "자기, 이제 우리 둘뿐이야…:0:21:0:0",
            "우리 둘이서 이 낙원을:0:21:0:0",
            "붉게:0:21:0:0",
            "더 붉게:0:21:0:0",
            "물들이자고:0:21:0:0",
            "후후후…:0:19:0:0" //흐콰_환희 어딧슴
            //암전 -> fin 문구 출력 -> 스탭롤
        });


        for (int i = 0; i < 36; i++)
        {
            portData.Add(i, portArr[i]);
        }
    }

    public string GetTalk(int id, int talkindex)
    {
        if (talkindex == talkData[id].Length)//대사 순서가 마지막이면 끝
            return null;
        else
            return talkData[id][talkindex];//아니면 id와 대사순서에 맞는것 출력
    }

    public Sprite GetPort(int portindex)
    {
        return portData[portindex];//그림중에 번호에 맞는것 출력
    }


}
