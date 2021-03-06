//
// Shows how to add/remove cells dynamically.
//

using System;
using MonoTouch.UIKit;
using MonoTouch.Dialog;

namespace Sample
{
	public partial class AppDelegate
	{
		const string longString = 
			"Today a major announcement was done in my kitchen, when " +
			"I managed to not burn the onions while on the microwave";
		
		UIImage badgeImage;
		
		public void DemoDate ()	
		{
			if (badgeImage == null)
				badgeImage = UIImage.FromFile ("jakub-calendar.png");
			
			var badgeSection = new Section ("Basic Badge Properties"){
				new BadgeElement (badgeImage, "New Movie Day") {
					Font = UIFont.FromName ("Helvetica", 36f)
				},
				new BadgeElement (badgeImage, "Valentine's Day"),
				
				new BadgeElement (badgeImage, longString) {
					Lines = 3,
					Font = UIFont.FromName ("Helvetica", 12f)
				}
			};
			
			//
			// Use the MakeCalendarBadge API
			//
			var font = UIFont.FromName ("Helvetica", 14f);
			var dates = new string [][] {
				new string [] { "January", "1", "Hangover day" },
				new string [] { "February", "14", "Valentine's Day" },
				new string [] { "March", "3", "Third day of March" },
				new string [] { "March", "31", "Prank Preparation day" },
				new string [] { "April", "1", "Pranks" },
			};
			var calendarSection = new Section ("Date sample");
			foreach (string [] date in dates){
				calendarSection.Add (new BadgeElement (BadgeElement.MakeCalendarBadge (badgeImage, date [0], date [1]), date [2]){
					Font = font
				});
			}
			
			var root = new RootElement ("Date sample") {
				calendarSection,
				badgeSection
			};
			var dvc = new DialogViewController (root, true);
			dvc.Style = UITableViewStyle.Plain;
			
			navigation.PushViewController (dvc, true);
		}
	}
}