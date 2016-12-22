# _Date-A-Base_

#### _Short Description._
## _This is a dating app for programmers that allows them to build a dating profile and seek other programmers., December 21, 2016 _

#### By _**Lina Shadrach, Brian Pritt, Taylor Loftis-Kim, James Howard**_

## Description
_Longer Description_
## _This app allows users to create a profile that will be used as their "Dating Profile". They will be able to edit multiple parameters of information, as well as add photos to their profile page. The User will be able to search for other profiles that are created, and see specific profiles that acquire matches. The User will be able to send messages to another profile, and that profile will be able to view the message, as well as reply to it. _


| SPECS                                                                   | INPUT                                                                              | OUTPUT                                                                                                            |
|-------------------------------------------------------------------------|------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------------------|
| Will return an empty Database                                           | null                                                                               | null                                                                                                              |
| Will allow User to Create a profile                                     |  Username: TaylorLoftisKim Password: *****aFirstName: Taylor LastName: Loftis Etc. | Profile: TaylorLoftisKim                                                                                          |
| Will allow User to Log-In to existing profile                           | Username: TaylorLoftisKim  Password: *****                                         | Profile Login Successful                                                                                          |
| Will allow User to update their profile                                 | Edit Profile:                                                                      | Username: TaylorLoftisKim Password: ***** FirstName: Taylor LastName: Loftis-Kim Email: taylorloftiskim@gmail.com |
| Will allow User to delete their profile                                 | Delete Profile:                                                                    | Database: null                                                                                                    |
| Will allow User to view all "Daters"                                    | View All Profiles:                                                                 | Taylor Loftis Brian Pritt                                                                                         |
| Will allow "Logged-In" User to edit their specific profile              | Edit Profile                                                                       | FirstName: Taylor LastName Loftis-Kim Etc.                                                                        |
| Will allow User to Log-Out of their profile                             | Log-Out                                                                            | Return to Sign-In Page                                                                                            |
| Will allow User to Tag their profile with muiltiple tags                | Edit Profile: Tags:                                                                | biking cars coffee hiking                                                                                         |
| Will allow User to search using Tags to locate profiles                 | Search Tags: biking cars coffee hiking                                             | TaylorLoftisKim                                                                                                   |
| Will allow User to send a message to a specific profile                 | Send Message: To Taylor: Hey there!                                                | Message Sent!                                                                                                     |
| Will allow User to View a unread message that was sent to their profile | View Unread Messages: From Brian:                                                  | From Brian: Hey there!                                                                                            |
| Will allow User to View all messages sent to them from other profiles   | View All Messages: From Brian:, From James:, From Lina:.                           | From Brian: Hey there!,  From James: How's it going?,  From Lina: Hello!                                          |
| Will allow User to View all messages that they sent to other users.     | View All Sent Messages: From TaylorLoftisKim:                                      | TaylorLoftisKim: To Brian: Yo.                                                                                    |
| Will allow User to delete specific messages sent from multiple profiles | View All Messages: From Brian: Yo --- DELETE                                       | View All Messages: null.                                                                                          |
|                                                                         |                                                                                    |                                                                                                                   |


## Setup/Installation Requirements

* _Download the repository [here](https://github.com/brianpritt/date-a-base "Date-A-Base Project"). Run on Windows with Powershell. In powershell, navigate into the repository directory and use command >dnx kestrel to run. Open up any browser window and enter localhost:5004 into URL search bar. Use command >dnx test to run tests in Test folder._

## Known Bugs

_None known._

## Support and contact details

_Please contact author through GitHub at username: brianpritt_

## Technologies and Resources Used

_HTML, CSS, C#, Xunit,  Nancy, Razor, Git, GitHub_

### License

*MIT*

Copyright (c) 2016 **_Lina Shadrach, Brian Pritt, Taylor Loftis-Kim, James Howard_**
