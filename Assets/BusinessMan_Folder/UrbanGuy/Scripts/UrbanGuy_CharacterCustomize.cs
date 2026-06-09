using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrbanGuy_CharacterCustomize : MonoBehaviour
{
	// Start is called before the first frame update
	private int bodyTyp;
	private int trousersTyp;
	private int tanktopTyp;
	private int hoodieTyp;
	private int hatTyp;
	
	private bool tanktopOld;
	private Transform hoodieT;
	private Transform tanktopT;
	private Transform bodyToHideT;
	private Transform hatT;
	private Transform hatFlipT;
	private Transform bodyT_A;
	private Transform bodyT_B;


	private UrbanGuy_AssetsList materialsList;

	private SkinnedMeshRenderer skinnedMeshRenderer;

	public enum BodySkin
	{
		V1,
		V2,
		V3,
		V4,
		V5
	}

	public enum TrousersSkin
	{
		V1,
		V2,
		V3,
		V4,
		V5

	}

	public enum TankTopSkin
	{
		None,
		V1,
		V2,
		V3,
		V4,
		V5,
		V6
	}
	public enum HoodieSkin
	{
		None,
		V1,
		V2,
		V3,
		V4,
		V5,
		V6
	}
	public enum HatSkin
	{
		None,
		V1,
		V2,
		V3,
		V4,
		V5
	}

	public BodySkin bodyType;
	public TrousersSkin trousersType;
	public TankTopSkin tanktopType;
	public HoodieSkin hoodieType;
	public HatSkin hatType;
	public bool hatFlip;
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}

	public void charCustomize(int body, int trousers, int tanktop, int hoodie, int hat, bool hatflip)
	{
		materialsList = gameObject.GetComponent<UrbanGuy_AssetsList>();
		Material[] mat;
		GameObject obj;
		hoodieT = transform.Find("Geo/Hoodie");
		tanktopT = transform.Find("Geo/TankTop");
		bodyToHideT = transform.Find("Geo/Body_ToHide");
		hatT = transform.Find("Geo/BaseballHat");
		hatFlipT = transform.Find("Geo/BaseballHat_Flipped");
		//bodyT_A = transform.Find("Geo/Body_Exposed");
		bodyT_B= transform.Find("Geo/Body_B_Exposed");

		// Body_Exposed

		for (int i = 0; i <= 3; i++)
		{


			Transform curSub = bodyT_B.Find("Body_Exposed_B_LOD" + i);

			Renderer skinRend = curSub.GetComponent<Renderer>();
			mat = new Material[2];
			mat[1] = materialsList.TrousersMaterials[trousers];
			mat[0] = materialsList.BodyMaterials[body];
			skinRend.materials = mat;



		}

		//BodyToHide

		for (int i = 0; i <= 3; i++)
		{
			Transform curSub = transform.Find("Geo/Body_ToHide/Body_ToHide_LOD" + i);
			
			

			Renderer skinRend = curSub.GetComponent<Renderer>();
			mat = new Material[2];
			mat[0] = materialsList.BodyMaterials[body];
			mat[1] = materialsList.TrousersMaterials[trousers];
			
			skinRend.materials = mat;

		}

		// Baseball Hat

		if (hatflip)
		{
			hatFlipT.gameObject.SetActive(true);
			hatT.gameObject.SetActive(false);
			print("hatFlipYes");
		}
		else
		{
			hatFlipT.gameObject.SetActive(false);
			hatT.gameObject.SetActive(true);
			print("hatFlipNo");
		}

		print(hatFlip);

		if (hat < 1)
		{
			
			hatT.gameObject.SetActive(false);
			hatFlipT.gameObject.SetActive(false);
		}

		else if(hatFlip)
		{
			
			hatFlipT.gameObject.SetActive(true);
			for (int i = 0; i <= 3; i++)
			{





				Transform curSub = hatFlipT.Find("BaseballHat_Flipped_LOD" + i);
				
				Renderer skinRend = curSub.GetComponent<Renderer>();
				skinRend.material = materialsList.HatMaterials[hat - 1];

			}

        }
        else
        {
			hatT.gameObject.SetActive(true);
			for (int i = 0; i <= 3; i++)
            {
				Transform curSub = hatT.Find("BaseballHat_LOD" + i);
				
				Renderer skinRend = curSub.GetComponent<Renderer>();
				skinRend.material = materialsList.HatMaterials[hat - 1];
			}
				
		}

		

		// Hoodie



		if (hoodie < 1)
		{
			
			hoodieT.gameObject.SetActive(false);
			bodyToHideT.gameObject.SetActive(true);
		}

		else
		{
			hoodieT.gameObject.SetActive(true);
			bodyToHideT.gameObject.SetActive(false);
			for (int i = 0; i <= 3; i++)
			{


				
				
				Transform curSub = hoodieT.Find("Hoodie_LOD" + i);
				
				Renderer skinRend = curSub.GetComponent<Renderer>();
				skinRend.material = materialsList.HoodieMaterials[hoodie - 1];
			}

			if (tanktopOld)
			{
				
				tanktopT.gameObject.SetActive(false);
				tanktopType = 0;
				tanktopOld = false;
				tanktop = 0;
				
			}

		}

		// TankTop

		
		if (tanktop < 1)
		{

			tanktopT.gameObject.SetActive(false);
		}

		else
		{
			tanktopT.gameObject.SetActive(true);
			bodyToHideT.gameObject.SetActive(true);
			for (int i = 0; i <= 3; i++)
			{
				


				Transform curSub = tanktopT.Find("TankTop_LOD" + i);
				
				Renderer skinRend = curSub.GetComponent<Renderer>();
				skinRend.material = materialsList.TankTopMaterials[tanktop - 1];


				tanktopOld = true;

			}
			
			hoodieT.gameObject.SetActive(false);
			
			hoodieType = 0;
			
		}


       

        






	}
	void OnValidate()
	{
		//code for In Editor customize
		bodyTyp = (int)bodyType;
		trousersTyp = (int)trousersType;
		tanktopTyp = (int)tanktopType;
		hoodieTyp = (int)hoodieType;
		hatTyp = (int)hatType;
	

		charCustomize(bodyTyp, trousersTyp, tanktopTyp, hoodieTyp, hatTyp, hatFlip);

	}
}
