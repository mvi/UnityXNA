using System;
using System.Collections.Generic;

public class DrawQueue
{
    List<DrawSpriteCall> spriteQueue = new List<DrawSpriteCall>();
	DrawSpriteCall[] lastSpriteQueue = new DrawSpriteCall[0];

    List<DrawStringCall> stringQueue = new List<DrawStringCall>();
    DrawStringCall[] lastStringQueue = new DrawStringCall[0];

    internal DrawSpriteCall[] LastSpriteQueue
    {
        get { return lastSpriteQueue; }
    }

    internal DrawStringCall[] LastStringQueue
    {
        get { return lastStringQueue; }
    }

	public DrawQueue ()
	{
	}
    public void Clear()
    {
		lastSpriteQueue = new DrawSpriteCall[spriteQueue.Count];
		spriteQueue.CopyTo(lastSpriteQueue);
        spriteQueue.Clear();

        lastStringQueue = new DrawStringCall[stringQueue.Count];
        stringQueue.CopyTo(lastStringQueue);
        stringQueue.Clear();
    }
    internal void EnqueueSprite(DrawSpriteCall drawSpriteCall)
    {
        spriteQueue.Add(drawSpriteCall);
    }

    internal void EnqueueString(DrawStringCall drawStringQueue)
    {
        stringQueue.Add(drawStringQueue);
    }
}
