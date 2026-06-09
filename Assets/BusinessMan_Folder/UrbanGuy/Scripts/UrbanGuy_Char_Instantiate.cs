using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UrbanGuy_Char_Instantiate : MonoBehaviour
{
	// Start is called before the first frame update
	private int bodyTyp;
	private int trousersTyp;
	private int tanktopTyp;
	private int hoodieTyp;
	private int hatTyp;
	private bool hatFlp;



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
	public Transform prefabObject;
	public BodySkin bodyType;
	public TrousersSkin trousersType;
	public TankTopSkin tanktopType;
	public HoodieSkin hoodieType;
	public HatSkin hatType;
	public bool hatFlip;
	void Start()
    {
		Transform pref = Instantiate(prefabObject, gameObject.transform.position, gameObject.transform.rotation);
		bodyTyp = (int)bodyType;
		trousersTyp = (int)trousersType;
		tanktopTyp = (int)tanktopType;
		hoodieTyp = (int)hoodieType;
		hatTyp = (int)hatType;
		hatFlp = hatFlip;
		pref.gameObject.GetComponent<UrbanGuy_CharacterCustomize>().hatFlip = hatFlip;
		pref.gameObject.GetComponent<UrbanGuy_CharacterCustomize>().charCustomize(bodyTyp, trousersTyp, tanktopTyp, hoodieTyp, hatTyp, hatFlp);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
