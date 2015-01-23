/****************************** GetImage.cs ********************************
 *
 *					(C) 2008, Lokai
 *			
 * Description: Command that displays a gump that lets you
 *	  browse all 16384 images in the game. Images are 
 *	  displayed 10 to a page. You can set the start image
 *	  at the command or in the Gump using the Text Box
 *	  provided.
 *	  
 * Updated November 5, 2009: Now lets you create Static items
 *	  from the list available by targeting a location.
 *	  
 * Modified by Lord Greywolf: Added Tiling of images, and case-
 *    insensitive searching.
 *    
 * Updated November 17, 2009: Added useful lists, browsing of
 *    images by name or first letter, and images hiding. GetImage
 *    command and gump incorporated into SearchImage.cs.
 *   
/***************************************************************************
 *
 *   This program is free software; you can redistribute it and/or modify
 *   it under the terms of the GNU General Public License as published by
 *   the Free Software Foundation; either version 2 of the License, or
 *   (at your option) any later version.
 *
 ***************************************************************************/
using System;
using Server;

namespace Server.Custom
{
	public class GetImageCommand
	{
		public static void Initialize()
		{
            //GetImage command moved to the SearchImage script.
		}
	}
}
