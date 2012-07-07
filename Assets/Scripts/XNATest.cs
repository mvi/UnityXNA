using UnityEngine;
using System.Collections;
using Platformer;

public class XNATest : MonoBehaviour {
    PlatformerGame game;
	DrawQueue drawQueue;
	
	public  float updateInterval = 0.5F;
 
	private float accum   = 0; // FPS accumulated over the interval
	private int   frames  = 0; // Frames drawn over the interval
	private float timeleft; // Left time for current interval
	float fps;
	// Use this for initialization
	void Start () 
    {
		Application.targetFrameRate = 60;

        // Add an audio source and tell the media player to use it for playing sounds
        Microsoft.Xna.Framework.Media.MediaPlayer.AudioSource = gameObject.AddComponent<AudioSource>();

		drawQueue = new DrawQueue();
        game = new PlatformerGame();
		game.DrawQueue = drawQueue;
        game.Begin();
		timeleft = updateInterval;  
		//Application.targetFrameRate = 30;
	}

	// Update is called once per frame
	void Update () {

		float deltaTime = Time.deltaTime;
		if(deltaTime > 0.050f)
		{
			deltaTime = 0.050f;
		}
		//Debug.Log(deltaTime);
		game.Tick(deltaTime);
        drawQueue.Clear();
		
		timeleft -= Time.deltaTime;
	    accum += Time.timeScale/Time.deltaTime;
	    ++frames;
	    
	    // Interval ended - update GUI text and start new interval
	    if( timeleft <= 0.0 )
	    {
	        // display two fractional digits (f2 format)
	  	  fps = accum/frames;
		
	 	   //  DebugConsole.Log(format,level);
	        timeleft = updateInterval;
	        accum = 0.0F;
	        frames = 0;
	    }
			
	}
	bool a= false;
	
    void OnGUI()
    {
        // Draw sprites from SpriteBatch.Draw()
		for (int i = 0; i < drawQueue.LastSpriteQueue.Length; i++) 
		{
			DrawSpriteCall call = drawQueue.LastSpriteQueue[i];
			float x = call.Position.X;
			float y = call.Position.Y;
			x -= call.Origin.X;
			y -= call.Origin.Y;
			float width = call.Texture2D.UnityTexture.width;
			float height = call.Texture2D.UnityTexture.height;
			GUI.color = new Color(call.Color.X,	call.Color.Y, call.Color.Z, call.Color.W);
			
			Rect sourceRect = new Rect(0,0, 1,1);
			
			if(call.Source != null)
			{
				sourceRect.x = call.Source.Value.X / width;
				sourceRect.y = call.Source.Value.Y / height;
				sourceRect.width = call.Source.Value.Width / width;
				sourceRect.height = call.Source.Value.Height / height;
			}
			
			if(call.SpriteEffects == Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipHorizontally)
			{
				sourceRect.x = 1-sourceRect.x;
				sourceRect.width *= -1;
			}
			else if(call.SpriteEffects == Microsoft.Xna.Framework.Graphics.SpriteEffects.FlipVertically)
			{
				sourceRect.y = 1-sourceRect.y;
				sourceRect.height *= -1;
			}
			
			GUI.DrawTextureWithTexCoords(new Rect(x,y,width * Mathf.Abs(sourceRect.width),height * Mathf.Abs(sourceRect.height)), call.Texture2D.UnityTexture, sourceRect);
			
		}
		
        // Draw strings from SpriteBatch.DrawString()
        for (int i = 0; i < drawQueue.LastStringQueue.Length; i++)
        {
            DrawStringCall call = drawQueue.LastStringQueue[i];
     
			GUI.color = new Color(call.Color.X,	call.Color.Y, call.Color.Z, call.Color.W);
			
            Vector2 size = GUI.skin.label.CalcSize(new GUIContent(call.Value));
            GUI.Label(new Rect(call.Position.X, call.Position.Y, size.x, size.y), call.Value);
        }

        //GUIStyle style = new GUIStyle();
        //style.font = Font.

        //GUILayout.Label()
		//GUI.color = Color.black;
        //GUILayout.Label(string.Format("{0} fps, {1} sprite draw calls", fps, drawQueue.LastSpriteQueue.Length));
    }
		

}
