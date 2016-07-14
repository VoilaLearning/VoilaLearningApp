using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using Prime31;

namespace Prime31
{
	public class EtceteraPictureGameController : MonoBehaviour {

		#if UNITY_IOS

		[SerializeField] PictureWordGame pictureWordGame;
		[SerializeField] Image imagePlane;
		string imagePath;

		void Start(){
			EtceteraManager.imagePickerChoseImageEvent += imagePickerChoseImage;
		}

		void OnDisable(){
			EtceteraManager.imagePickerChoseImageEvent += imagePickerChoseImage;
		}

		public void OpenCamera(){
			EtceteraBinding.promptForPhoto (0.25f, PhotoPromptType.Camera);
		}

		public void LoadPicture(){
			if (imagePath == null) {
				Debug.Log ("Must take a picture before loading");
				return;
			}

			/* FOR TESTING */
			// pictureWordGame.SetPictureLoaded (true);
			StartCoroutine (EtceteraManager.textureFromFileAtPath ("file://" + imagePath, textureLoaded, textureLoadFailed));
		}

		public void SavePhotoToAlbum(){

			if( imagePath == null ) {
				Debug.Log("Take a picture before saving.");
				return;
			}

			EtceteraBinding.saveImageToPhotoAlbum( imagePath );
		}

		public void TakeScreenShot(){
			StartCoroutine( EtceteraBinding.takeScreenShot( "someScreenshot.png", imagePath =>
				{
					Debug.Log( "Screenshot taken and saved to: " + imagePath );
				}) );
		}

		void imagePickerChoseImage( string imagePath ) {
			this.imagePath = imagePath;
		}

		// Texture loading delegates
		public void textureLoaded( Texture2D texture ) {
			Rect rect = new Rect (0,0,texture.width,texture.height);
			Vector2 pivot = new Vector2(0.5f,0.5f);
			Sprite newPic = Sprite.Create (texture, rect, pivot);

			imagePlane.sprite = newPic;
			pictureWordGame.SetPictureLoaded (true);
		}


		public void textureLoadFailed( string error )
		{
			var buttons = new string[] { "OK" };
			EtceteraBinding.showAlertWithTitleMessageAndButtons( "Error Loading Texture.  Did you choose a photo first?", error, buttons );
			Debug.Log( "textureLoadFailed: " + error );
		}

		#endif
	}
}