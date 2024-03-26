using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using IDAutomation.LinearServerControl;

namespace ASPLinearServerControl
{
	/// <summary>
	/// Summary description for GenerateImage.
	/// </summary>
	public partial class GenerateImage : System.Web.UI.Page
	{
	
		protected void Page_Load(object sender, System.EventArgs e)
		{
			//During the page load event we will set all parameters for the control			
			//Checking the Parameters using Params.Get is NOT case sensitive.  
			//However, when we use the Equals method of the string data type it IS case sensitive
			
			//set the Symbology
			if(Request.Params.Get("CODE_TYPE") != "" && Request.Params.Get("CODE_TYPE") != null)
			{
				try
				{
					int CodeTypeValue = Convert.ToInt32(Request.Params.Get("CODE_TYPE"));
					switch (CodeTypeValue)
					{
						case 0:
							LinearBarcode1.SymbologyID = LinearBarcode.Symbologies.Code39;
							break;
						case 1:
							LinearBarcode1.SymbologyID = LinearBarcode.Symbologies.Code39Ext;
							break;
						case 2:
							LinearBarcode1.SymbologyID = LinearBarcode.Symbologies.Interleaved25;
							break;
						case 3:
							LinearBarcode1.SymbologyID = LinearBarcode.Symbologies.Code11;
							break;
						case 4:
							LinearBarcode1.SymbologyID = LinearBarcode.Symbologies.Codabar;
							break;
						case 5:
							LinearBarcode1.SymbologyID = LinearBarcode.Symbologies.MSI;
							break;
						case 6:
							LinearBarcode1.SymbologyID = LinearBarcode.Symbologies.UPCa;
							break;
						case 7:
							LinearBarcode1.SymbologyID = LinearBarcode.Symbologies.Ind25;
							break;
						case 8:
							LinearBarcode1.SymbologyID = LinearBarcode.Symbologies.Mat25;
							break;
						case 9:
							LinearBarcode1.SymbologyID = LinearBarcode.Symbologies.Code93;
							break;
						case 10:
							LinearBarcode1.SymbologyID = LinearBarcode.Symbologies.Ean13;
							break;
						case 11:
							LinearBarcode1.SymbologyID = LinearBarcode.Symbologies.Ean8;
							break;
						case 12:
							LinearBarcode1.SymbologyID = LinearBarcode.Symbologies.UPCe;
							break;
						case 13:
							LinearBarcode1.SymbologyID = LinearBarcode.Symbologies.Code128;
							break;
						case 14:
							LinearBarcode1.SymbologyID = LinearBarcode.Symbologies.Planet;
							break;
						case 15:
							LinearBarcode1.SymbologyID = LinearBarcode.Symbologies.Postnet;
							break;
						case 16:
							LinearBarcode1.SymbologyID=LinearBarcode.Symbologies.Code93Ext;
							break;
						
						case 17:
                           LinearBarcode1.SymbologyID = LinearBarcode.Symbologies.UCC128;
							break;
                        case 18:
                           LinearBarcode1.SymbologyID = LinearBarcode.Symbologies.OneCode;
							break;
					}
				}
				catch
				{
					System.Diagnostics.Debug.Write("Invalid entry for Code Type value");
				}
			}

			//Set the Data to Encode
			if(Request.Params.Get("Barcode") != "" && Request.Params.Get("Barcode") != null)
				LinearBarcode1.DataToEncode = Request.Params.Get("Barcode");

			//Set the x dimension
			if(Request.Params.Get("X") != "" && Request.Params.Get("X") != null)
				LinearBarcode1.XDimensionCM = Request.Params.Get("X");

			//set the bar height
			if(Request.Params.Get("Bar_Height") != "" && Request.Params.Get("Bar_Height") != null)
				LinearBarcode1.BarHeightCM = Request.Params.Get("Bar_Height");
			
			//determine if the check character should be calculated
			if(Request.Params.Get("Check_Char") != "" && Request.Params.Get("Check_Char") != null)
			{
				string checkCharValue = Request.Params.Get("Check_Char");
				if(checkCharValue.Equals("Y") == true || checkCharValue.Equals("Yes") == true ||
					checkCharValue.Equals("True") == true || checkCharValue.Equals("TRUE") == true ||
					checkCharValue.Equals("y") == true || checkCharValue.Equals("true") == true ||
					checkCharValue.Equals("yes") == true)
					
					LinearBarcode1.CheckCharacter = true;
				else
					LinearBarcode1.CheckCharacter = false;
			}

			//determine if the check character should be displayed in the text
			if(Request.Params.Get("Check_Char_Text") != "" && Request.Params.Get("Check_Char_Text") != null)
			{
				string checkCharTextValue = Request.Params.Get("Check_Char_Text");
				
				if(checkCharTextValue.Equals("Y") == true || checkCharTextValue.Equals("Yes") == true ||
					checkCharTextValue.Equals("True") == true || checkCharTextValue.Equals("TRUE") == true ||
					checkCharTextValue.Equals("y") == true || checkCharTextValue.Equals("true") == true ||
					checkCharTextValue.Equals("yes") == true)
					
					LinearBarcode1.CheckCharacterInText = true;
				else
					LinearBarcode1.CheckCharacterInText = false;
			}

			//determine if the check character should be displayed in the text
			if(Request.Params.Get("ACTT") != "" && Request.Params.Get("ACTT") != null)
			{
				string checkCharTextValue = Request.Params.Get("ACTT");
				
				if(checkCharTextValue.Equals("Y") == true || checkCharTextValue.Equals("Yes") == true ||
					checkCharTextValue.Equals("True") == true || checkCharTextValue.Equals("TRUE") == true ||
					checkCharTextValue.Equals("y") == true || checkCharTextValue.Equals("true") == true ||
					checkCharTextValue.Equals("yes") == true)
					
					LinearBarcode1.CheckCharacterInText = true;
				else
					LinearBarcode1.CheckCharacterInText = false;
			}


			//set the rotation
			if(Request.Params.Get("Rotate") != "" && Request.Params.Get("Rotate") != null)
			{
				if(Request.Params.Get("Rotate").Equals("90"))
					LinearBarcode1.RotationAngle = LinearBarcode.RotationAngles.Ninety_Degrees;
				else if(Request.Params.Get("Rotate").Equals("180"))
					LinearBarcode1.RotationAngle = LinearBarcode.RotationAngles.One_Hundred_Eighty_Degrees;
				else if(Request.Params.Get("Rotate").Equals("270"))
					LinearBarcode1.RotationAngle = LinearBarcode.RotationAngles.Two_Hundred_Seventy_Degrees;
				else
					LinearBarcode1.RotationAngle = LinearBarcode.RotationAngles.Zero_Degrees;
			}

			//Should the human readable text be displayed
			if(Request.Params.Get("Show_Text") != "" && Request.Params.Get("Show_Text") != null)
			{
				string ShowTextValue = Request.Params.Get("Show_Text");
				//Equals method IS case sensitive
				if(ShowTextValue.Equals("Y") == true || ShowTextValue.Equals("Yes") == true ||
					ShowTextValue.Equals("True") == true || ShowTextValue.Equals("TRUE") == true ||
					ShowTextValue.Equals("y") == true || ShowTextValue.Equals("true") == true ||
					ShowTextValue.Equals("yes") == true)
					
					LinearBarcode1.ShowText = true;
				else
					LinearBarcode1.ShowText = false;
			}

			//Should the human readable text be displayed
			if(Request.Params.Get("ST") != "" && Request.Params.Get("ST") != null)
			{
				string ShowTextValue = Request.Params.Get("ST");
				//Equals method IS case sensitive
				if(ShowTextValue.Equals("Y") == true || ShowTextValue.Equals("Yes") == true ||
					ShowTextValue.Equals("True") == true || ShowTextValue.Equals("TRUE") == true ||
					ShowTextValue.Equals("y") == true || ShowTextValue.Equals("true") == true ||
					ShowTextValue.Equals("yes") == true)
					
					LinearBarcode1.ShowText = true;
				else
					LinearBarcode1.ShowText = false;
			}
			
			//set the left margin
			if(Request.Params.Get("Left_Margin") != "" && Request.Params.Get("Left_Margin") != null)
				LinearBarcode1.LeftMarginCM = Request.Params.Get("Left_Margin");

			//Set the resolution of the returned image
			if(Request.Params.Get("IR") != "" && Request.Params.Get("IR") != null)
			{
				try
				{
					LinearBarcode1.ImageResolution  = Convert.ToInt32(Request.Params.Get("IR"));
				}
				catch
				{
					System.Diagnostics.Debug.Write("Invalid entry for Image Resolution parameter");
				}
			}
        
			//set the top margin
			if(Request.Params.Get("Top_Margin") != "" && Request.Params.Get("Top_Margin") != null)
				LinearBarcode1.TopMarginCM = Request.Params.Get("Top_Margin");

			//Set the Code 128 character set
			if(Request.Params.Get("CODE128_Set") != "" && Request.Params.Get("CODE128_Set") != null)
			{
				try
				{
					int Code128SetValue = Convert.ToInt32(Request.Params.Get("CODE128_Set"));
					switch (Code128SetValue)
					{
						case 0:
							LinearBarcode1.Code128Set = LinearBarcode.Code128CharacterSets.Auto;
							break;
						case 1:
							LinearBarcode1.Code128Set = LinearBarcode.Code128CharacterSets.A;
							break;
						case 2:
							LinearBarcode1.Code128Set = LinearBarcode.Code128CharacterSets.B;
							break;
						case 3:
							LinearBarcode1.Code128Set = LinearBarcode.Code128CharacterSets.C;
							break;
					}
				}
				catch
				{
					System.Diagnostics.Debug.Write("Invalid entry for Code 128 Character set value");
				}
			}


			//Set the narrow to wide ratio
			if(Request.Params.Get("Narrow_Wide") != "" && Request.Params.Get("Narrow_Wide") != null)
				LinearBarcode1.NarrowToWideRatio = Request.Params.Get("Narrow_Wide");

			//Set the narrow to wide ratio
			if(Request.Params.Get("N") != "" && Request.Params.Get("N") != null)
				LinearBarcode1.NarrowToWideRatio = Request.Params.Get("N");

			//Set the margin between text and barcode
			if(Request.Params.Get("Text_Margin") != "" && Request.Params.Get("Text_Margin") != null)
				LinearBarcode1.TextMarginCM = Request.Params.Get("Text_Margin");

			//Set the height of short bars for postnet
			if(Request.Params.Get("Postnet_Tall") != "" && Request.Params.Get("Postnet_Tall") != null)
				LinearBarcode1.PostnetHeightTall = Request.Params.Get("Postnet_Tall");

			//Set the height of tall bars for postnet
			if(Request.Params.Get("Postnet_Short") != "" && Request.Params.Get("Postnet_Short") != null)
				LinearBarcode1.PostnetHeightShort = Request.Params.Get("Postnet_Short");

			//set the spacing between bars for postnet
			if(Request.Params.Get("Postnet_Space") != "" && Request.Params.Get("Postnet_Space") != null)
				LinearBarcode1.PostnetSpacing = Request.Params.Get("Postnet_Space");
		
			//set the WhiteBarIncrease
			if (Request.Params.Get("WhiteBarIncrease") != "" && Request.Params.Get("WhiteBarIncrease") != null)
				LinearBarcode1.WhiteBarIncrease = Request.Params.Get("WhiteBarIncrease");

			//set the WhiteBarIncrease
			if (Request.Params.Get("WhiteBar_Increase") != "" && Request.Params.Get("WhiteBar_Increase") != null)
				LinearBarcode1.WhiteBarIncrease = Request.Params.Get("WhiteBar_Increase");

			//set the Character Grouping
			if (Request.Params.Get("CharacterGrouping") != "" && Request.Params.Get("CharacterGrouping") != null)
				LinearBarcode1.CharacterGrouping = Request.Params.Get("CharacterGrouping");

			//set the Character Grouping
			if (Request.Params.Get("Character_Grouping") != "" && Request.Params.Get("Character_Grouping") != null)
				LinearBarcode1.CharacterGrouping = Request.Params.Get("Character_Grouping");

			//set the CaptionAbove
			if (Request.Params.Get("CaptionAbove") != "" && Request.Params.Get("CaptionAbove") != null) 
				LinearBarcode1.CaptionAbove = Request.Params.Get("CaptionAbove");

			//set the CaptionBelow
			if (Request.Params.Get("CaptionBelow") != "" && Request.Params.Get("CaptionBelow") != null) 
				LinearBarcode1.CaptionBelow = Request.Params.Get("CaptionBelow");

			//set the BearerBarHorizontal
			if (Request.Params.Get("BearerBarHorizontal")!= "" && Request.Params.Get("BearerBarHorizontal")!= null )
				LinearBarcode1.BearerBarHorizontal = Request.Params.Get("BearerBarHorizontal");

			//set the BearerBarHorizontal
			if (Request.Params.Get("BearerBar_Horizontal")!= "" && Request.Params.Get("BearerBar_Horizontal")!= null )
				LinearBarcode1.BearerBarHorizontal = Request.Params.Get("BearerBar_Horizontal");

	        //set the BearerBarVertical
		    if (Request.Params.Get("BearerBarVertical") != "" && Request.Params.Get("BearerBarVertical") != null )
			    LinearBarcode1.BearerBarVertical = Request.Params.Get("BearerBarVertical");

			//set the BearerBarVertical
			if (Request.Params.Get("BearerBar_Vertical") != "" && Request.Params.Get("BearerBar_Vertical") != null )
				LinearBarcode1.BearerBarVertical = Request.Params.Get("BearerBar_Vertical");

			//Determine if ApplyTilde is turned on
			if(Request.Params.Get("PT") != "" && Request.Params.Get("PT") != null)
			{
				string trunValue = Request.Params.Get("PT");
				if(trunValue.Equals("Y") == true || trunValue.Equals("Yes") == true ||
					trunValue.Equals("True") == true || trunValue.Equals("TRUE") == true ||
					trunValue.Equals("y") || trunValue.Equals("true") == true ||
					trunValue.Equals("yes"))
					LinearBarcode1.ApplyTilde = true;
				else
					LinearBarcode1.ApplyTilde = false;
			}

			//The following is an example for changing the font and colors of the image.
//			LinearBarcode1.ForeColor = System.Drawing.Color.Yellow;
//			LinearBarcode1.BackColor = System.Drawing.Color.Black;
//			LinearBarcode1.Font.Name = "Georgia";
//			LinearBarcode1.Font.Size = 16;
//			LinearBarcode1.TextFontColor = System.Drawing.Color.Yellow; 

			//To change the format of the image that is streamed to the browser change the second parameter of 
			//the function call below. 
			Response.ContentType = "image/gif";
			//LinearBarcode1.GetBitmapImageForBinaryStream().Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
			
			LinearBarcode1.GetBitmapImageForBinaryStream().Save(Response.OutputStream, System.Drawing.Imaging.ImageFormat.Gif);
            //LinearBarcode1.GetBitmapImageForBinaryStream().Save("C:/Inetpub/wwwroot/Inventory/Images/" + Request.Params.Get("CaptionAbove").ToString()+ ".gif", System.Drawing.Imaging.ImageFormat.Gif);
        }

		#region Web Form Designer generated code
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: This call is required by the ASP.NET Web Form Designer.
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{    

		}
		#endregion
	}
}
