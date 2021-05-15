using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
using SO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public SOItemsHolder Holder;
    
    
    
    
    
    
    public MenuScr menuScr;
    public bool DelAll;
    public AudioSource Sounds;
    public AudioSource Music;
    public AudioClip StartMusic;
    public AudioClip MusicBG;
    public AudioClip MusicBGMiniGames;
    public AudioClip MusicWolf;
    public AudioClip GrandMotherMusic;
    public AudioClip[] SoundsGame;
    public GameObject LivingRoom;
    public GameObject BedRoom;
    public GameObject Forest;
    public GameObject Street;
    public GameObject OldHome;
    public GameObject Basement;
    public GameObject Glade;

    private Inventory inventory;
    private ItemController itemController;
    //Living Room
    public GameObject ClosedEmail;
    public GameObject OpenEmail;
    public GameObject Room;
    public GameObject Inventory;
    public GameObject ZoomCell;
    public GameObject ZoomChest;
    public GameObject ZoomGramophone;
    public GameObject CloseDoorCell;
    public GameObject OpenDoorCell;
    public GameObject Feed;
    public GameObject PointStop;
    public GameObject[] Gramophone;
    public GameObject Disk;

    //BedRoom
    public GameObject ZoomHome;
    public GameObject ZoomTable;
    public GameObject ZoomPiano;
    public GameObject ZoomBooks;
    public GameObject Paper;
    public GameObject PaperCod;
    public GameObject GreenBook;
    public GameObject RedBook;
    public GameObject Dool;
    public GameObject Roof;
    public GameObject RaycastHome;
    public GameObject Notes;
    public GameObject RoofPiano;
    public GameObject Nuts;

    //Street
    public GameObject ZoomMailBox;
    public GameObject ZoomFoliage;
    public GameObject Foliage;
    public GameObject[] OpenMailBox;
    public GameObject[] Fence;

    //Forest
    public GameObject ZoomHollow;
    public GameObject[] Squirrel;
    public GameObject DoorOldHome;
    public GameObject[] Castle;
    public GameObject ClickOldHome;
    private bool isOpenDoorOldHome = false;
    public int Brige;

    //OldHome
    public GameObject Web;
    public GameObject ZoomDeer;
    public GameObject ClickHandle;
    public GameObject Panel;
    public GameObject[] Bear;
    public GameObject[] Horn;
    public int PuzzleNumber;

    //Basement
    public GameObject[] Cap;
    public GameObject[] BasementOpenClose;

    //Glade
    public GameObject Earth;
    public GameObject[] Tree;
    public GameObject Leshy;
    public GameObject Ball;

    //Swamp
    public GameObject Toils;
    public GameObject[] Bush;
    public GameObject ZoomCave;
    public GameObject Heart;

    public Feed feed;

    private GameObject inventoryBttn;
    public GameObject inventoryBttn1;
    public int RightBook;
    private bool isOpenDoor = false;
    private bool isOpenDoorStreet = false;
    public bool CraftMode = false;
    public GameObject DownCraftBttn;
    public RedBook redBook;
    public int MiniGameActive;
    public int MiniGameActive2;
    public GameObject MiniGameObject;
    public GameObject MiniGameObject2;
    public bool isActiveClick = true;
    public int AllRignt = 0;
    public int SceneNumber = 0;
    private InterstitialAd ad;
    public GameObject PrivacyPolice;
    public Slot slot;

    private const string AdVideo = "ca-app-pub-3146812254351410/4442036299";

    void Start()
    {
        if (PlayerPrefs.GetInt("Ver")==1)
        {
            menuScr.RussiaVersion();
        }
        inventory = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Inventory>();
        itemController = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<ItemController>();
        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            PrivacyPolice.SetActive(true);
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
        }
        if (PlayerPrefs.GetInt("PlayStartMusic") == 1)
        {
            Music.Play();
        }
        if(PlayerPrefs.GetInt("ChoiseObject") > 0)
        {
            var number = PlayerPrefs.GetInt("ChoiseObject");
            //for (int i = 0; i < inventory.slots.Length; i++)
            //{
            //    if (inventory.Full[i] == false)
            //    {
            //        inventory.Full[i] = true;
            //        Instantiate(slot.Item[number - 1], inventory.slots[i].transform);
            //        break;
            //    }
            //}
        }
        if (DelAll)
        {
            PlayerPrefs.DeleteAll();
        }
    }
    public void Help()
    {
        Application.OpenURL("https://youtu.be/qIHrX0ba8io");
    }

    public void LearnMore()
    {
        Application.OpenURL("http://www.lesogames.com/privacy.html");
    }
    public void OnAdLoaded(object sender,System.EventArgs args)
    {
        ad.Show();
    }
    public void CraftBttn()
    {
        if (inventory.CraftMode)
        {
            inventory.CraftMode = false; 
            DownCraftBttn.SetActive(false);
        }
        else
        {
            inventory.CraftMode = true;
            DownCraftBttn.SetActive(true);
        }
        Sounds.PlayOneShot(SoundsGame[43]);
    }
    public void ClickOpenEmail(AudioClip Open)
    {
        Sounds.PlayOneShot(Open);
        ClosedEmail.SetActive(false);
        OpenEmail.SetActive(true);
    }
    public void ClickCloseEmail()
    {
        OpenEmail.SetActive(false);
        Room.SetActive(true);
        MusicPlay(MusicBG);
    }
    public void InventoryPanel()
    {
        Image img = inventoryBttn1.transform.GetChild(0).GetComponent<Image>();
        if (Inventory.activeSelf == false)
        {
            Inventory.SetActive(true);
            inventoryBttn1.transform.position = new Vector2(inventoryBttn1.transform.position.x - 100, inventoryBttn1.transform.position.y);
            
        }
        else
        {
            Inventory.SetActive(false);
            inventoryBttn1.transform.position = new Vector2(inventoryBttn1.transform.position.x + 100, inventoryBttn1.transform.position.y);
            
        }
    }
    public void UIManager(GameObject Panel)
    {
        if (Panel.activeSelf) Panel.SetActive(false);
        else Panel.SetActive(true);
        SceneNumber += 1;
        if(SceneNumber >= 15)
        {
            ad = new InterstitialAd(AdVideo);
            AdRequest request = new AdRequest.Builder().Build();
            ad.LoadAd(request);
            ad.OnAdLoaded += OnAdLoaded;
            SceneNumber = 0;
        }
    }
    public void ClickOpenDoorCell()
    {
        CloseDoorCell.SetActive(false);
        OpenDoorCell.SetActive(true);
        Feed.SetActive(true);
        PlayerPrefs.SetInt("OpenCellDoor", 1);
        Sounds.PlayOneShot(SoundsGame[1]);

    }

    public void FeedClik()
    {
        Debug.Log("FeedClick");
        if (inventory.CheckHandItemName("Seed"))/////////////////////////////////////// 
        {
            ClearInventory();
            Feed.SetActive(false);
            feed.isFeedClick = true;
            Sounds.PlayOneShot(SoundsGame[0]);
        }
    }

    public void OpenDoor()
    {
        Debug.Log("OpenDoor");
        var number = PlayerPrefs.GetInt("DoorOpenBR");
        if (number == 1)
        {
            isOpenDoor = true;
        }
        if (inventory.CheckHandItemName("DoorHandle"))/////////////////////////////////////// 
        {
            ClearInventory();
            LivingRoom.SetActive(false);
            BedRoom.SetActive(true);
            isOpenDoor = true;
            PlayerPrefs.SetInt("DoorOpenBR", 1);
            Sounds.PlayOneShot(SoundsGame[40]);
        }
        else if (isOpenDoor)
        {
            LivingRoom.SetActive(false);
            BedRoom.SetActive(true);
            SceneNumber += 1;
        }
        else
        {
            Sounds.PlayOneShot(SoundsGame[39]);
        }

    }
    public void ExitBedRoom()
    {
        BedRoom.SetActive(false);
        LivingRoom.SetActive(true);
    }

    public void ClickGramophone()
    {
        if (inventory.CheckHandItemName("Gramophone"))/////////////////////////////////////// 
        {
            ClearInventory();
            Gramophone[0].SetActive(true);
            Gramophone[1].SetActive(true);   
            PlayerPrefs.SetInt("GramophoneClick", 1);
            Sounds.PlayOneShot(SoundsGame[8]);
        }
    }
    public void DestroyDisk(GameObject Acid)
    {
        if (Gramophone[0].activeSelf)
        {
            Acid.SetActive(true);
            Disk.SetActive(false);
        }
    }
    public void ZoomHomeOpenClose()
    {
        if (ZoomHome.activeSelf) ZoomHome.SetActive(false);
        else ZoomHome.SetActive(true);
    }
    public void ZoomTableOpenClose()
    {
        if (ZoomTable.activeSelf) ZoomTable.SetActive(false);
        else ZoomTable.SetActive(true);
    }
    public void ClickCandle()
    {
        if (inventory.CheckHandItemName("Paper")) /////////////////////////////////////// 
        {
            ClearInventory();
            Paper.SetActive(true);
            NewItemInventory("PaperCode");
        }
    }
    public void ZoomPianoOpenClose()
    {
        if (inventory.CheckHandItemName("Book") && ZoomPiano.activeSelf == false) ///////////////
        {
            ClearInventory();
            Notes.SetActive(true);
            RoofPiano.SetActive(true);
            Nuts.SetActive(true);
            PlayerPrefs.SetInt("ZoomPiano", 1);
            Sounds.PlayOneShot(SoundsGame[16]);
        }
        else if (ZoomPiano.activeSelf) ZoomPiano.SetActive(false);
        else ZoomPiano.SetActive(true);
    }

    public void ZoomBooksOpenClose()
    {
        if (ZoomBooks.activeSelf) ZoomBooks.SetActive(false);
        else ZoomBooks.SetActive(true);
    }
    public void OpenDoorStreet()
    {
        Debug.Log("OpenDoorStreet");
        var number = PlayerPrefs.GetInt("OpenDoorStreet");
        if (number == 1)
        {
            isOpenDoorStreet = true;
        }
        if (inventory.CheckHandItemName("KeyFromDoorStreet")) /////////////////////////////////////// 
        {
            ClearInventory();
            Street.SetActive(true);
            LivingRoom.SetActive(false);
            isOpenDoorStreet = true;
            PlayerPrefs.SetInt("OpenDoorStreet", 1);
            Sounds.PlayOneShot(SoundsGame[13]);
        }
        else if (isOpenDoorStreet)
        {
            SceneNumber += 1;
            Street.SetActive(true);
            LivingRoom.SetActive(false);
        }
    }
    public void CloseDoorStreet()
    {
        Street.SetActive(false);
        LivingRoom.SetActive(true);
    }
    public void ClickZoomMailBox()
    {
        if (ZoomMailBox.activeSelf) ZoomMailBox.SetActive(false);
        else ZoomMailBox.SetActive(true);
    }
    public void ActivateFlag()
    {
        if (inventory.CheckHandItemName("Flag")) /////////////////////////////////////// 
        {
            ClearInventory();
            OpenMailBox[0].SetActive(true);
            OpenMailBox[1].SetActive(true);
            Destroy(OpenMailBox[2]);
            PlayerPrefs.SetInt("ActiveFlag", 1);
            Sounds.PlayOneShot(SoundsGame[15]);
        }
    }
    public void ClickZoomFoliage()
    {
        if (ZoomFoliage.activeSelf) ZoomFoliage.SetActive(false);
        else ZoomFoliage.SetActive(true);
    }

    public void CuttingLeaves()
    {
        if (inventory.CheckHandItemName("Secateur") && ZoomFoliage.activeSelf == true)////////////////////////////
        {
            ClearInventory();
            Destroy(Foliage);
            Sounds.PlayOneShot(SoundsGame[14]);
            PlayerPrefs.SetInt("CuttingLeaves", 1);
        }
    }
    public void ClickBook()
    {
        if (inventory.CheckHandItemName("GreenBook")) /////////////////////////////////////// 
        {
            ClearInventory();
            GreenBook.SetActive(true);
            redBook.GreanBookActive = true;
        }
    }
    public void ClickDool()
    {
        if (inventory.CheckHandItemName("Doll")) /////////////////////////////////////// 
        {
            ClearInventory();
            Dool.SetActive(true);
            Roof.SetActive(false);
            RaycastHome.SetActive(false);
            Sounds.PlayOneShot(SoundsGame[36]);
            PlayerPrefs.SetInt("ClickDoolHome", 1);
        }
    }
    public void OpenFence()
    {
        var number = PlayerPrefs.GetInt("Kettle");
        if (number == 1)
        {
            Fence[0].SetActive(false);
            Fence[1].SetActive(true);
        }
        if (inventory.CheckHandItemName("Kettle")) /////////////////////////////////////// 
        {
            ClearInventory();
            Fence[0].SetActive(false);
            Fence[1].SetActive(true);
            PlayerPrefs.SetInt("OpenFence", 1);
            Sounds.PlayOneShot(SoundsGame[1]);
        }
    }
    public GameObject Kod4916;
    public void ClickWell(GameObject gameObject)
    {
        if(inventory.CheckHandItemName("Rope")) /////////////////////////////////////// 
        {
            ClearInventory();
            gameObject.SetActive(true);
            PlayerPrefs.SetInt("ClickWell", 1);
        }
    }

    public void GoExitForest()
    {
        if (Forest.activeSelf) { Forest.SetActive(false); Street.SetActive(true); }
        else Forest.SetActive(true);
    }

    public void ClickZoomHollow()
    {
        if (ZoomHollow.activeSelf) ZoomHollow.SetActive(false);
        else ZoomHollow.SetActive(true);
    }
    public void FeedSquirrel()
    {
        if (inventory.CheckHandItemName("Nuts")) /////////////////////////////////////// 
        {
            ClearInventory();
            Destroy(Squirrel[0]);
            Destroy(Squirrel[1]);                    //<--------------
            PlayerPrefs.SetInt("FeedSquirrel", 1);
            Sounds.PlayOneShot(SoundsGame[3]);
        }
    }
    public void ZoomDoorOldHome()
    {
        if (DoorOldHome.activeSelf) DoorOldHome.SetActive(false);
        else DoorOldHome.SetActive(true);
    }
    public GameObject[] DoorOldHomeOpenClose;
    public void OpenCastle()
    {
        if (inventory.CheckHandItemName("Acid")) /////////////////////////////////////// 
        {
            ClearInventory();
            Castle[0].SetActive(false);
            Castle[1].SetActive(true);
            ClickOldHome.SetActive(true);
            isOpenDoorOldHome = true;
            Sounds.PlayOneShot(SoundsGame[1]);
            Destroy(DoorOldHomeOpenClose[0]);
            DoorOldHomeOpenClose[1].SetActive(true);
            PlayerPrefs.SetInt("OpenCastle", 1);
        }
    }
    public void ChopWood(GameObject gameObject)
    {
        if(inventory.CheckHandItemName("Axe")) /////////////////////////////////////// 
        {
            ClearInventory();
            Destroy(gameObject);
            PlayerPrefs.SetInt("ChopWood", 1);
            Sounds.PlayOneShot(SoundsGame[44]);
        }
    }
    private bool icClickBrige = false;
    public void ClickBrige(GameObject BrigePanel)
    {
        if(inventory.CheckHandItemName("FireWood")) /////////////////////////////////////// 
        {
            ClearInventory();
            BrigePanel.SetActive(true);
            icClickBrige = true;
            PlayerPrefs.SetInt("ClickBrige", 1);
        }
        else if(icClickBrige)
        {
            BrigePanel.SetActive(true);
        }
    }
    public void GoOldHome(GameObject gameObject)
    {
        if (isOpenDoorOldHome)
        {
            if (OldHome.activeSelf) OldHome.SetActive(false);
            else OldHome.SetActive(true); gameObject.SetActive(false);
        }
    }

    public void RemoveWeb()
    {
        if (inventory.CheckHandItemName("Broom")) /////////////////////////////////////// 
        {
            ClearInventory();
            Destroy(Web);
            PlayerPrefs.SetInt("RemoveWeb", 1);
        }
    }
    public void ClickDeer()
    {
        if (inventory.CheckHandItemName("Horn")) /////////////////////////////////////// 
        {
            ClearInventory();
            Horn[0].SetActive(true);
            Horn[1].SetActive(true);
            Panel.SetActive(false);
            PlayerPrefs.SetInt("ClickDeer", 1);
        }
    }

    public void ClickBear()
    {
        Bear[0].SetActive(false);
        Bear[1].SetActive(true);
        Sounds.PlayOneShot(SoundsGame[41]);
        PlayerPrefs.SetInt("ClickBear", 1);
    }

    public void OpenCap()
    {
        if (inventory.CheckHandItemName("Scrap")) /////////////////////////////////////// 
        {
            ClearInventory();
            Cap[0].SetActive(false);
            Cap[1].SetActive(true);
            Cap[2].SetActive(false);
            Cap[3].SetActive(true);
            Sounds.PlayOneShot(SoundsGame[25]);
            PlayerPrefs.SetInt("OpenCap", 1);
        }
    }
    private bool isOpenBasement = false;
    public void OpenBasement()
    {
        var number = PlayerPrefs.GetInt("OpenBasement");
        if (number == 1)
        {
            isOpenBasement = true;
        }
        if (inventory.CheckHandItemName("Handle")) /////////////////////////////////////// 
        {
            ClearInventory();
            BasementOpenClose[0].SetActive(false);
            BasementOpenClose[1].SetActive(true);
            isOpenBasement = true;
            PlayerPrefs.SetInt("OpenBasement", 1);
        }
        else if (isOpenBasement)
        {
            Basement.SetActive(true);
        }
    }

    private bool isDigEarth = false;
    public void DigEarth()
    {
        if (inventory.CheckHandItemName("Shovel")) /////////////////////////////////////// 
        {
            ClearInventory();
            Earth.SetActive(false);
            isDigEarth = true;
            Sounds.PlayOneShot(SoundsGame[26]);
            PlayerPrefs.SetInt("DigEarth", 1);
        }
    }
    public void FertilizerTree()
    {
        if (inventory.CheckHandItemName("Bag") && isDigEarth)/////////////////////////
        {
            ClearInventory();
            Tree[0].SetActive(false);
            Tree[1].SetActive(true);
            Tree[2].SetActive(true);
            Sounds.PlayOneShot(SoundsGame[27]);
        }
    }
    public void MiniGamesOldHome(GameObject gameObject)
    {
        gameObject.SetActive(true);
        MusicPlay(MusicBGMiniGames);
    }
    public void CloseMiniGameOldHome(GameObject gameObject)
    {
        gameObject.SetActive(false);
        MusicPlay(MusicBG);    
    }
    public void GoGladeAndTree(GameObject gameObject)
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            MusicPlay(MusicBG);
        }
        else
        {
            gameObject.SetActive(true);
            MusicPlay(MusicWolf);            
        }
    }
    public void GoForestAnd(GameObject gameObject)
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            MusicPlay(MusicWolf);
        }
        else
        {
            gameObject.SetActive(true);
            MusicPlay(MusicBG);
        }
    }
    public void StaffLeshy()
    {
        if (inventory.CheckHandItemName("Staff")) /////////////////////////////////////// 
        {
            ClearInventory();
            Destroy(Leshy);
            NewItemInventory("RedBall");
        }
    }
    public void ToilsDestroy(GameObject gameObject)
    {
        if (inventory.CheckHandItemName("Knife")) /////////////////////////////////////// 
        {
            ClearInventory();
            Destroy(Toils);
            Destroy(gameObject);
            Sounds.PlayOneShot(SoundsGame[19]);
            PlayerPrefs.SetInt("ToilsDestroy", 1);
        }
    }
    public void DestroyClickObject(GameObject gameObject)
    {
        Destroy(gameObject);
    }
    public void Water(GameObject EmptyBacket)
    {
        if (inventory.CheckHandItemName("EmptyBucket")) /////////////////////////////////////// 
        {
            ClearInventory();
            NewItemInventory("Bucket");
            Sounds.PlayOneShot(SoundsGame[46]);
        }
    }
    public void FireFighting()
    {
        if (inventory.CheckHandItemName("Bucket")) /////////////////////////////////////// 
        {
            Bush[0].SetActive(false);
            Bush[1].SetActive(true);
            Bush[2].SetActive(false);
            Bush[3].SetActive(true);
            ClearInventory();
            PlayerPrefs.SetInt("FireFighting", 1);
            Sounds.PlayOneShot(SoundsGame[9]);
        }
    }
    public void LightCave()
    {
        if (inventory.CheckHandItemName("LampOn")) /////////////////////////////////////// 
        {
            //TODO Баг с отсутсвием анимации а именно белый спрайт
            ClearInventory();
            ZoomCave.SetActive(true);
            PlayerPrefs.SetInt("LightCave", 1);
        }
    }
    public GameObject[] FindAWay;
    public void FindWay()
    {
        if (inventory.CheckHandItemName("RedBall")) /////////////////////////////////////// 
        {
            ClearInventory();
            FindAWay[0].SetActive(false);
            FindAWay[1].SetActive(true);
            FindAWay[2].SetActive(true);
            Sounds.PlayOneShot(SoundsGame[38]);
            PlayerPrefs.SetInt("FindWay", 1);
        }
    }
    public GameObject[] Trap;
    public void ClickTrap()
    {
        if (inventory.CheckHandItemName("Stick")) /////////////////////////////////////// 
        {
            ClearInventory();
            Trap[0].SetActive(false);
            Trap[1].SetActive(true);
            Trap[2].SetActive(false);
            Trap[3].SetActive(true);
            NewItemInventory("Hearth");
            Sounds.PlayOneShot(SoundsGame[30]);
            PlayerPrefs.SetInt("ClickTrap", 1);
        }
    }
    public GameObject Beess;
    public void Bees()
    {
        if (inventory.CheckHandItemName("SmokeOn")) /////////////////////////////////////// 
        {
            ClearInventory();
            Destroy(Beess);
            Sounds.PlayOneShot(SoundsGame[20]);
            PlayerPrefs.SetInt("Bees", 1);
        }
    }
    public GameObject Nenuphars;
    public GameObject Jemchug;
    public void ReedpipeGoblin()
    {
        if (inventory.CheckHandItemName("ReedPipe")) /////////////////////////////////////// 
        {
            ClearInventory();
            Nenuphars.SetActive(true);
            Sounds.PlayOneShot(SoundsGame[7]);
            NewItemInventory("Pearl");
            PlayerPrefs.SetInt("GoblinReedpipe", 1);
        }
    }
    public GameObject HeartScarecrow;
    public Hook hook;
    public void ClickScarecrow()
    {
        if (inventory.CheckHandItemName("Hearth")) /////////////////////////////////////// 
        {
            ClearInventory();
            HeartScarecrow.SetActive(true);
            hook.isClick = true;
            PlayerPrefs.SetInt("ClickScarecrow", 1);
        }
    }
    private int flap = 0;
    public Flap Flap;
    public GameObject FlapDontZoom;
    public void ClickFlap(GameObject gameObject)
    {
        if (inventory.CheckHandItemName("Screwdriver")) /////////////////////////////////////// 
        {
            gameObject.SetActive(true);
            flap += 1;
            Sounds.PlayOneShot(SoundsGame[4]);
            if (flap == 4)
            {
                ClearInventory();
                FlapDontZoom.SetActive(false);
                Flap.isClick = true;
                PlayerPrefs.SetInt("ClickFlap", 1);
            }
        }
    }
    public void ClearLeaves(GameObject gameObject)
    {
        if (inventory.CheckHandItemName("Rake")) /////////////////////////////////////// 
        {
            ClearInventory();
            gameObject.SetActive(false);
            Sounds.PlayOneShot(SoundsGame[34]);
            PlayerPrefs.SetInt("ClearLeaves", 1);
        }
    }
    public GameObject MiniGamePanel;
    public GameObject DoorTree;
    private bool isOpenDoorTree = false;
    public void OpenDoorTree()
    {
        if (inventory.CheckHandItemName("StoneBlue")) /////////////////////////////////////// 
        {
            ClearInventory();
            MiniGamePanel.SetActive(true);
            isOpenDoorTree = true;
            PlayerPrefs.SetInt("OpenDoorTree", 1);
        }
        else if (isOpenDoorTree == true)
        {
            MiniGamePanel.SetActive(true);
        }
    }
    public GameObject GoForestAndWell;
    public void BoomTree(GameObject gameObject)
    {
        if (inventory.CheckHandItemName("DynamiteOn")) /////////////////////////////////////// 
        {
            ClearInventory();
            GoForestAndWell.SetActive(true);
            Destroy(gameObject);
            Sounds.PlayOneShot(SoundsGame[6]);
            PlayerPrefs.SetInt("BoomTree", 1);
        }
    }
    public GameObject[] Flower;
    public void EatFlower()
    {
        if (inventory.CheckHandItemName("Moth")) /////////////////////////////////////// 
        {
            ClearInventory();
            Flower[0].SetActive(false);
            Flower[1].SetActive(true);
            Sounds.PlayOneShot(SoundsGame[18]);
            PlayerPrefs.SetInt("EatFlower", 1);
        }
    }
    public GameObject[] Vagonetka;
    private bool VagonetkaSWheel;
    public void ClickVagonetka()
    {
        if (inventory.CheckHandItemName("Wheel")) /////////////////////////////////////// 
        {
            ClearInventory();
            Vagonetka[0].SetActive(false);
            Vagonetka[1].SetActive(true);
            VagonetkaSWheel = true;
            PlayerPrefs.SetInt("ClickVagonetka", 1);
        }
        else if (VagonetkaSWheel == true)
        {
            Vagonetka[1].SetActive(false);
            Vagonetka[2].SetActive(true);
            Sounds.PlayOneShot(SoundsGame[5]);
        }
    }
    public GameObject Ventil;
    public void BreakUpStone(GameObject gameObject)
    {
        if (inventory.CheckHandItemName("PickAxe")) /////////////////////////////////////// 
        {
            ClearInventory();
            NewItemInventory("Ventil");
            Destroy(gameObject);
            PlayerPrefs.SetInt("BreakUpStone", 1);
        }
    }
    public void OpenDoorCave2(GameObject gameObject)
    {
        if (inventory.CheckHandItemName("KeyWell")) /////////////////////////////////////// 
        {
            ClearInventory();
            Destroy(gameObject);
            Sounds.PlayOneShot(SoundsGame[14]);
            PlayerPrefs.SetInt("OpenDoorCave2", 1);
        }
    }
    public GameObject[] HeadDragon;
    public void ClickStoneHeadDragon()
    {
        if (inventory.CheckHandItemName("BlueCrystal")) /////////////////////////////////////// 
        {
            ClearInventory();
            HeadDragon[0].SetActive(false);
            HeadDragon[1].SetActive(true);
            Sounds.PlayOneShot(SoundsGame[37]);
            PlayerPrefs.SetInt("ClickStoneHeadDragon", 1);
        }
    }
    public GameObject KulonObject;
    public void ClickKulon(GameObject Kulon)
    {
        if (inventory.CheckHandItemName("FishingRod")) /////////////////////////////////////// 
        {
            ClearInventory();
            NewItemInventory("Kulon");
            Destroy(KulonObject);
            Sounds.PlayOneShot(SoundsGame[29]);
        }
    }
    public void ReturnKulon()
    {
        if (inventory.CheckHandItemName("Kulon")) /////////////////////////////////////// 
        {
            ClearInventory();
            NewItemInventory("Lupa");
        }
    }
    private int findZnak = 0;
    public GameObject[] DoorCave;
    public void FindZnak(GameObject gameObject)
    {
        if (inventory.CheckHandItemName("Lupa")) /////////////////////////////////////// 
        {
            findZnak += 1;
            gameObject.SetActive(true);
            Sounds.PlayOneShot(SoundsGame[33]);
            if (findZnak == 5)
            {
                ClearInventory();
                DoorCave[0].SetActive(false);
                DoorCave[1].SetActive(true);
                Sounds.PlayOneShot(SoundsGame[45]);
                PlayerPrefs.SetInt("FindZnak", 1);
            }
        }
    }
    public GameObject[] Grob;
    public void OpenGrob()
    {
        if (inventory.CheckHandItemName("Axe2")) /////////////////////////////////////// 
        {
            ClearInventory();
            Grob[0].SetActive(false);
            Grob[1].SetActive(true);
            Grob[2].SetActive(true);
            PlayerPrefs.SetInt("OpenGrob", 1);
            Sounds.PlayOneShot(SoundsGame[35]);
        }
    }
    public GameObject[] Fontanium;
    public void ClickFountain()
    {
        if (inventory.CheckHandItemName("Ventil")) /////////////////////////////////////// 
        {
            ClearInventory();
            Fontanium[0].SetActive(false);
            Fontanium[1].SetActive(true);
            Sounds.PlayOneShot(SoundsGame[21]);
            PlayerPrefs.SetInt("ClickFountain", 1);

        }
    }
    public void ClickJungle(GameObject gameObject)
    {
        if (inventory.CheckHandItemName("SharpBraid")) /////////////////////////////////////// 
        {
            ClearInventory();
            Destroy(gameObject);
            Sounds.PlayOneShot(SoundsGame[22]);
            PlayerPrefs.SetInt("ClickJungle", 1);
        }
    }
    public int MiniGamePuzzleFinal, MiniGamePuzzleFinal1, MiniGamePuzzleFinal2;
    public GameObject MiniGamePanelFinal;
    public GameObject OpenDoorFinal;
    public void WinMiniPuzzleGame()
    {
        Destroy(MiniGamePanelFinal);
        Destroy(OpenDoorFinal);
    }
    private bool isOpenBox = false;
    public GameObject[] Box;
    public void OpenBox(GameObject Shnurok)
    {
        if (inventory.CheckHandItemName("Scissors")) /////////////////////////////////////// 
        {
            ClearInventory();
            Destroy(Shnurok);
            isOpenBox = true;
            PlayerPrefs.SetInt("OpenBox", 1);
        }
        else if (isOpenBox == true)
        {
            Destroy(Box[0]);
            Box[1].SetActive(true);
        }
    }
    public GameObject Axe;
    public GameObject BoxMiniGame;
    public void ClickShar(GameObject Shar)
    {
        if (inventory.CheckHandItemName("Ball2")) /////////////////////////////////////// 
        {
            ClearInventory();
            Shar.SetActive(true);
            NewItemInventory("Axe2");
            StartCoroutine(DelayCloseBoxMiniGame());
            Sounds.PlayOneShot(SoundsGame[32]);
            PlayerPrefs.SetInt("ClickShar", 1);
        }
    }
    IEnumerator DelayCloseBoxMiniGame()
    {
        yield return new WaitForSeconds(0.3f);
        BoxMiniGame.SetActive(false);
    }

    public void ClickApples(GameObject Apples)
    {
        if (inventory.CheckHandItemName("Basket")) /////////////////////////////////////// 
        {
            ClearInventory();
            Destroy(Apples);
            Sounds.PlayOneShot(SoundsGame[23]);
        }
    }
    public GameObject[] Wolf;
    public void FreezWolf()
    {
        if (inventory.CheckHandItemName("PotionFreeze")) /////////////////////////////////////// 
        {
            ClearInventory();
            Destroy(Wolf[0]);
            Wolf[1].SetActive(true);
            Sounds.PlayOneShot(SoundsGame[31]);
            PlayerPrefs.SetInt("FreezWolf", 1);
        }
    }
    public void RemoveCoal(GameObject Coal)
    {
        if (inventory.CheckHandItemName("PokerPok")) /////////////////////////////////////// 
        {
            ClearInventory();
            Destroy(Coal);
            PlayerPrefs.SetInt("RemoveCoal", 1);
        }
    }
    public GameObject[] ClockDoor;
    public void ClickClock()
    {
        if (inventory.CheckHandItemName("Pendul")) /////////////////////////////////////// 
        {
            ClearInventory();
            Destroy(ClockDoor[0]);
            ClockDoor[1].SetActive(true);
            ClockDoor[2].SetActive(true);
            ClockDoor[3].SetActive(true);
            PlayerPrefs.SetInt("ClickClock", 1);

        }
    }
    private bool isOpenDoorGrandMother = false;
    public GameObject BedRoomGrandMother;
    public void OpenDoorGrandMother()
    {
        if (inventory.CheckHandItemName("OpenDoorGrandMother")) /////////////////////////////////////// 
        {
            ClearInventory();
            isOpenDoorGrandMother = true;
            BedRoomGrandMother.SetActive(true);
        }
        else if (isOpenDoorGrandMother)
        {
            BedRoomGrandMother.SetActive(true);
        }
    }
    private int ingredient = 0;
    public void Potion(GameObject PotionObj)
    {
        if (ingredient == 0 && inventory.CheckHandItemName("Flower")) /////////////////////////////////////// 
        {
            ClearInventory();
            PotionObj.GetComponent<Image>().color = new Color(0, 1, 0.456346f);
            ingredient += 1;
            Sounds.PlayOneShot(SoundsGame[12]);
        }
        else if (ingredient == 1 && inventory.CheckHandItemName("Pearl")) /////////////////////////////////////// 
        {
            ClearInventory();
            PotionObj.GetComponent<Image>().color = new Color(0.8808007f, 1, 0);
            ingredient += 1;
            Sounds.PlayOneShot(SoundsGame[12]);
        }
        else if (ingredient == 2 && inventory.CheckHandItemName("StoneGreen")) /////////////////////////////////////// 
        {
            ClearInventory();
            PotionObj.GetComponent<Image>().color = new Color(0, 0.3683066f, 1);
            ingredient += 1;
            Sounds.PlayOneShot(SoundsGame[12]);
        }
        else if (ingredient == 3 && inventory.CheckHandItemName("Berries")) /////////////////////////////////////// 
        {
            ClearInventory();
            PotionObj.GetComponent<Image>().color = new Color(1, 0, 0.220675f);
            ingredient += 1;
            Sounds.PlayOneShot(SoundsGame[12]);
        }
        else if (ingredient == 4 && inventory.CheckHandItemName("LivingWater")) /////////////////////////////////////// 
        {
            ClearInventory();
            PotionObj.GetComponent<Image>().color = new Color(0, 1, 0.7507141f);
            ingredient += 1;
            Sounds.PlayOneShot(SoundsGame[12]);
        }
    }
    public GameObject Plate;
    public GameObject PlateItem;
    public void ClickPlate()
    {
        if (ingredient == 5)
        {
            Destroy(Plate);
            NewItemInventory("Potion");
        }
    }
    public GameObject[] BookIngridient;
    public void ClickOpenBook()
    {
        Destroy(BookIngridient[0]);
        BookIngridient[1].SetActive(true);
    }
    public GameObject Picture;
    public void ClickPicture()
    {
        if (inventory.CheckHandItemName("Picture")) /////////////////////////////////////// 
        {
            ClearInventory();
            Picture.SetActive(true);
            PlayerPrefs.SetInt("ClickPicture", 1);
        }
    }
    public GameObject[] GrandMother;
    public GameObject[] Final;
    public AudioClip FinalMusic;
    public GameObject Menu;

    public void ClickGrandMother()
    {
        if(inventory.CheckHandItemName("ClickGrandMother")) /////////////////////////////////////// 
        {
            ClearInventory();
            Destroy(GrandMother[0]);
            GrandMother[1].SetActive(true);
            StartCoroutine(DelayFinla());
            MusicPlay(FinalMusic);
        }
    }
    public void CloseDialog(GameObject Dialog)
    {
        Destroy(Dialog);
    }
    IEnumerator DelayFinla()
    {
        yield return new WaitForSeconds(2f);
        Final[0].SetActive(true);
        yield return new WaitForSeconds(5f);
        Final[1].SetActive(true);
        yield return new WaitForSeconds(5f);
        Menu.SetActive(true);
        Final[0].SetActive(false);
        Final[1].SetActive(false);
    }
    public void GoHomeGrandMother(GameObject gameObject)
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
            MusicPlay(MusicBG);
        }
        else
        {
            gameObject.SetActive(true);
            MusicPlay(MusicWolf);
        }
    }
    private bool DoorGranBotherBedRoom = false;
    public void GoBedRoomGrandMother(GameObject gameObject)
    {
        var number = PlayerPrefs.GetInt("GoBedRoomGrandMother");
        if (number == 1)
        {
            DoorGranBotherBedRoom = true;
        }
        if (inventory.CheckHandItemName("Key3")) /////////////////////////////////////// 
        {
            ClearInventory();
            gameObject.SetActive(true);
            MusicPlay(GrandMotherMusic);
            DoorGranBotherBedRoom = true;
            PlayerPrefs.SetInt("GoBedRoomGrandMother", 1);

        }
        else if(DoorGranBotherBedRoom)
        {
            gameObject.SetActive(true);
            MusicPlay(GrandMotherMusic);
        }
    }
    public void ExitRoomGrandMother(GameObject gameObject)
    {
        gameObject.SetActive(false);
        MusicPlay(MusicWolf);
    }
    //----------------------------------------------------------------//
    void ClearInventory()
    {
        //inventoryBttn = GameObject.FindGameObjectWithTag("IconItem");
        //Destroy(itemController.choiceItemSlot);
        //Destroy(inventoryBttn);
        //inventory.SelectedItemID = 0;
        //inventory.mailIsFull = false;
        inventory.Unequipt(true);
    }

    void NewItemInventory(string name)
    {
        inventory.CreateItemByName(name);
    }

    public void MusicPlay(AudioClip audioClip)
    {
        Music.clip = audioClip;
        Music.Play();
    }
    void SoundsPlay(AudioClip audioClip)
    {
        Sounds.PlayOneShot(audioClip);
    }
    void SaveProgres(string KeyName)
    {
        var number = PlayerPrefs.GetInt(KeyName);
        PlayerPrefs.SetInt(KeyName, 1);
    }
    //----------------------------------------------------------------//
}
