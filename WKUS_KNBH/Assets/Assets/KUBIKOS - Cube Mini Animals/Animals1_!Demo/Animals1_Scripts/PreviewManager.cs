using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;  //씬 변경해줄려고 선언함 

namespace Animmal.Animmals1
{
    public enum ANIMATORSTYLE { fourlegged, flying, bipedal, human}
    [System.Serializable]
    public class AssetDB
    {
        public string Name;
        public ANIMATORSTYLE AnimatorStyle;
        public SKINS AssetSkins;
        public Vector3 Offset;
  
    }
    public class PreviewManager : MonoBehaviour
    {
        #region VARIABLES


        [Header("Assets")]
        public bool LoopAssets = true;
        public List<AssetDB> AssetDB;
        public float AssetTransitionTime = 2f;

        [Header("Settings")]
        public int DefaultFov = 60;
        public int MaxZoomOutFov = 90;
        public int MinZoominFov = 40;
        public int DefaultRotation = -122;
        public int MinRotation = -270;
        public int MaxRotation = 90;


        [Header("SceneSetup")]
        public Camera DemoCamera;
        public Transform StageCenter;
        public Transform RightOffStage;
        public Transform LeftOffStage;

        [Header("UISetup")]
        public Text AssetName;
        [Space(5f)]        
        public Slider RotationSlider;
        public Slider ZoomSlider;
        public Slider SkinSlider;
        public Image BlockerSliders;
        public Image BlockerButtons;
        [Space(5f)]
        public Button Idle;
        public Button Walk;
        public Button Run;
        public Button Jump;

        public static int CurrentItemID = 0;
        int CurrentSkinID = 0;

        AssetsObject AssetsItem1;
        AssetsObject AssetsItem2;
        int CurrentObjectOnStage = 0;

        bool buttonsLocked;
        bool ButtonsLocked
        {
            get
            {
                return buttonsLocked;
            }
            set
            {
                buttonsLocked = value;
                if (value)
                {
                    BlockerSliders.gameObject.SetActive(true);
                    BlockerButtons.gameObject.SetActive(true);
                    
                }
                else
                {
                    BlockerSliders.gameObject.SetActive(false);
                    BlockerButtons.gameObject.SetActive(false);
                }
            }
        }
        #endregion

        #region SETUP

       
        private void Start()
        {
            ZoomSlider.minValue = MinZoominFov;
            ZoomSlider.maxValue = MaxZoomOutFov;
            ZoomSlider.value = DefaultFov;

            RotationSlider.minValue = MinRotation;
            RotationSlider.maxValue = MaxRotation;
            RotationSlider.value = DefaultRotation;

            SetupAssetItems();
            SetupSkinSlider();
            SetupAnimationButtons();
            SetupAssetName();
        }
        private void Update()   //내가 선언한 것 캐릭터 고를 때 나오는 고유 번호로 캐릭터 선택하게 함 
        {
            //Debug.Log("현재 ID :" + CurrentItemID);
            Select_Character.number = CurrentItemID;
        }
        void SetupAssetItems()
        {
            AssetsItem1 = new GameObject().AddComponent<AssetsObject>();
            AssetsItem1.gameObject.name = "Assets1";
            AssetsItem1.Init(AssetDB);
            AssetsItem1.gameObject.transform.eulerAngles = new Vector3(0, DefaultRotation, 0);
            AssetsItem1.transform.position = StageCenter.position;
            AssetsItem2 = Instantiate(AssetsItem1) as AssetsObject;
            AssetsItem2.gameObject.name = "Assets2";
            AssetsItem2.transform.position = RightOffStage.position;
            AssetsItem2.gameObject.transform.eulerAngles = new Vector3(0, DefaultRotation, 0);
        }

        void SetupSkinSlider()
        {
            SkinSlider.maxValue = AssetDB[CurrentItemID].AssetSkins.Skins.Count - 1;
            SkinSlider.value = 0;
        }

        void SetupAssetName()
        {
            AssetName.text = AssetDB[CurrentItemID].Name.ToUpper() + "  -  Triangle Count: " + OnStageItem().GetObjectTriangleCount().ToString();
        }

        void SetupAnimationButtons()
        {
            switch (AssetDB[CurrentItemID].AnimatorStyle)
            {
                case ANIMATORSTYLE.fourlegged:
                    Idle.gameObject.SetActive(true);                   
                    Walk.gameObject.SetActive(true);
                    Run.gameObject.SetActive(true);                    
                    Jump.gameObject.SetActive(true);
                    break;

                case ANIMATORSTYLE.flying:
                    Idle.gameObject.SetActive(true);                    
                    Walk.gameObject.SetActive(false);
                    Run.gameObject.SetActive(false);                    
                    Jump.gameObject.SetActive(true);                        
                    break;

                case ANIMATORSTYLE.bipedal:
                    Idle.gameObject.SetActive(true);                   
                    Walk.gameObject.SetActive(true);
                    Run.gameObject.SetActive(false);                
                    Jump.gameObject.SetActive(true);
                    break;

                case ANIMATORSTYLE.human:
                    Idle.gameObject.SetActive(true);                
                    Walk.gameObject.SetActive(true);
                    Run.gameObject.SetActive(true);                            
                    break;

                default:
                    break;

            }
        }

        #endregion

        #region BUTTONS

        
        public void LeftClicked()
        {
            if (ButtonsLocked)
                return;

            if (CurrentItemID == 0)
            {
                if (LoopAssets)
                    CurrentItemID = AssetDB.Count - 1;
                else
                    return;
            }
            else
                CurrentItemID--;

            OffStageItem().SetObject(CurrentItemID);
            OffStageItem().transform.position = RightOffStage.position;
            StartCoroutine(MoveAssets(LeftOffStage.position, RightOffStage.position));
        }

        public void RightClicked()
        {
            if (ButtonsLocked)
                return;

            if (CurrentItemID == AssetDB.Count - 1)
            {
                if (LoopAssets)
                    CurrentItemID = 0;
                else
                    return;
            }
            else
                CurrentItemID++;

            OffStageItem().SetObject(CurrentItemID);
            OffStageItem().transform.position = LeftOffStage.position;
            StartCoroutine(MoveAssets(RightOffStage.position, LeftOffStage.position));
        }

        public void PlayAnimation(string _AnimTrigger)
        {
            OnStageItem().SetAnimation(_AnimTrigger);
        }

        public void RotationSliderValueChanged()
        {
            if (OnStageItem() != null)
                OnStageItem().transform.eulerAngles = new Vector3(0, RotationSlider.value, 0);
        }
        public void ZOOMSliderValueChanged()
        {
            DemoCamera.fieldOfView = ZoomSlider.value;
        }
        public void SKINSliderValueChanged()
        {
            OnStageItem().SetSkin((int)SkinSlider.value);
        }
        #endregion

        #region ASSETMOVEMENT


        IEnumerator MoveAssets(Vector3 _OffStageEndPoint, Vector3 _OnStageStartPoint)
        {
            ButtonsLocked = true;
       
            OffStageItem().transform.eulerAngles = new Vector3(0, DefaultRotation, 0);

            float elapsedTime = 0;
            Vector3 startingPos = transform.position;
            while (elapsedTime < AssetTransitionTime)
            {
                OnStageItem().transform.position = Mathfx.EasyInOut(StageCenter.position, _OffStageEndPoint, (elapsedTime / AssetTransitionTime));
                OffStageItem().transform.position = Mathfx.EasyInOut(_OnStageStartPoint, StageCenter.position, (elapsedTime / AssetTransitionTime));
                elapsedTime += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            OnStageItem().transform.position = _OffStageEndPoint;
            OnStageItem().transform.eulerAngles = new Vector3(0, DefaultRotation, 0);
            OffStageItem().transform.position = StageCenter.position;
            RotationSlider.value = -90;
            
            SwitchOnScreenItem();
            SetupSkinSlider();
            SetupAnimationButtons();
            SetupAssetName();
            ButtonsLocked = false;
        }
        


        AssetsObject OnStageItem()
        {
            if (CurrentObjectOnStage == 0)
                return AssetsItem1;
            else
                return AssetsItem2;
        }

        AssetsObject OffStageItem()
        {
            if (CurrentObjectOnStage == 0)
                return AssetsItem2;
            else
                return AssetsItem1;
        }

        void SwitchOnScreenItem()
        {
            if (CurrentObjectOnStage == 0)
                CurrentObjectOnStage = 1;
            else
                CurrentObjectOnStage = 0;
        }

        #endregion

        //내가 선언한 것
        public void Select_Btn()
        {           
            SceneManager.LoadScene(1);
        }
    }
}