# Mobile-Game-Documentation
Food Frenzy is a fast-paced 2D casual action game where players collect healthy foods like strawberries, bananas, and apples to earn points while avoiding unhealthy obstacles like burgers, pizza, and steak that reduce their score. Designed with simple mechanics for accessibility, players can use touch, gyro or drag controls to navigate the game. 

With vibrant visuals, engaging gameplay, and features like haptic feedback, rewarded ads, and score-based challenges, Food Frenzy provides a fun and interactive experience for players of all ages.

## <ins> Overview:
### Genre: ​Arcade​, Casual​

### Objective: ​
- Collect all healthy food falling down.​
- Gain more than 40 before the timer ends.
- Avoid all unhealthy food.​

### Key Features:
- Touchscreen Input - Drag input movement
- Gyroscope - Gyro input movement
- Accelerometer - Shake Input
- Mute and Unmute UI
- Pause UI
- Advertisments
- Login System

## <ins> Monthly Log

### October:
#### Game Mechanics and UI enhancements
A food spawner was implemented to generate food items, awarding points upon collection. Movement button icons were updated with a new arrow design to better align with the game’s theme. GUI improvements included a redesigned main menu background, a fully functional settings button, and an initial attempt at incorporating gyro input options. A table was introduced to enhance aesthetics and serve as a visible boundary for the player. 

Gyro input was successfully implemented and could be enabled through the settings menu. While attempts were made at including drag-based movement, it remained incomplete. A responsive pause menu was added, featuring options to resume, restart, or quit the game, although functionality required multiple taps to activate. Vibration feedback was added for collisions, and a timer was introduced to trigger endgame mechanics. Food assets were updated to PNG format, and the background visuals received a significant upgrade.

### November:
#### Monetization and Audio integration. 
An initial attempt at implementing ads was made, with plans to include rewarded ads for better engagement. Background music was added to the menu and main level, programmed to pause when the options or pause menu was active and resume upon closing. Early work on obstacles began but required further refinement.

### December:
#### Polishing Game Mechanics. 
Obstacles were successfully implemented, deducting 5 points upon collision, with safeguards to prevent scores from dropping below zero. A system to destroy off-screen objects was introduced to minimize lag and maintain performance. Development of a point pop-up GUI was nearly complete. Plans were outlined to integrate APIs for Google services, such as leaderboards and login functionality, along with adjustable vibration settings to enhance player experience.

### January:
#### Final Touch Ups - Advanced Gameplay Features & Enhancements.
The point pop-up system was finalized, with color customization and haptic feedback added using the HapticFeedback GitHub library. Rewarded ads were successfully implemented, enabling players to earn gems for watching videos. Sound effects for collisions were integrated, using 8-bit assets for a retro aesthetic. A new food theme was introduced, featuring healthy foods such as strawberries, bananas, and apples that award points, while unhealthy foods like burgers, pizza, and steak served as obstacles that deduct points. Collision mechanics were rebalanced for improved gameplay experience. GUI updates included the addition of mute/unmute buttons for music and a Firebase-authenticated login menu, streamlining user access. Endgame logic was refined to display a win for scores of 40 or higher when the timer ends, and a loss for scores below 40. The game was submitted for internal testing on Google Play.

## <ins> References:

### <ins> Articles​:

- Vidal, S. (2023). Why is Subway Surfers so popular?  [online] Available at: https://tecnobits.com/en/por-que-subway-surfers-es-tan-popular/ [Accessed 19 Oct. 2024].​
Knezovic,  A. (2023). Subway Surfers: Lessons from the Record-Breaking Mobile Game. [online] Available at: https://www.blog.udonis.co/mobile-marketing/mobile-games/subway-surfers [Accessed 19 Oct. 2024].​
- Haridas, P. (2016). How Fruit Ninja Achieved 1 Billion Downloads Over 5 Years. [online] Available at: https://www.referralcandy.com/blog/fruit-ninja-marketing-strategy. [Accessed 19 Oct. 2024].​
- BOIA (2023). Does Comic Sans Benefit People with Dyslexia? [online] Available at: https://www.boia.org/blog/does-comic-sans-benefit-people-with-dyslexia. [Accessed 19 Oct. 2024].​
- Ralph (2024). The Changing Face of Casual Mobile Games: H1 2024 Market Insights [online] Available at: https://www.gamerbraves.com/the-changing-face-of-casual-mobile-games-h1-2024-market-insights/ [Accessed 19 Oct. 2024].​
- CrazyLabs (2024). Cracking the Code: CrazyLabs’ Gaming Experts Reveal 2024 Mobile Gaming Trends. [online] Available at: https://www.crazylabs.com/blog/gaming-experts-reveal-mobile-gaming-trends/ [Accessed 19 Oct. 2024].​
- Knezovic,  A. (2023). Casual Games Market in 2024: Trends, CPIs, ROAS, and More! [online] Available at: https://www.blog.udonis.co/mobile-marketing/mobile-games/casual-games [Accessed 19 Oct. 2024].​
- gameuidatabase (2016). Game UI Database - Clash Royale. [online] Available at: https://gameuidatabase.com/gameData.php?id=1299 [Accessed 19 Oct. 2024].​
- Newzoo (2024) Newzoo’s Global Games Market Report 2024 [online] Available at: https://resources.newzoo.com/hubfs/Free%20Reports/Games%20Market%20Report%20and%20Forecasts/2024_Newzoo_Free_Global_Games_Market_Report.pdf [Accessed 19 October 2024]​
- Castellani, P (2024) Mobile Games Ads 2024: Monetization Strategies and User Acquisition Trends [online] https://mapendo.co/blog/mobile-game-ads-revenue-2024 [Accessed 19 October 2024]

### <ins> Scripts:
- AIA (2021). How to EASILY make a TIMER in Unity [online] Available at: https://www.youtube.com/watch?v=27uKJvOpdYw [Accessed 20 Oct 2024]
- Cyber, C (2021) How To Random Object Spawns in Unity 2D [online] Available at: https://www.youtube.com/watch?v=j6p5Nh7JvmY [Accessed 20 Oct 2024]
- Leonardo, D (2021) Drag and Drop for Mobile & Desktop in Unity [online] Available at: https://www.youtube.com/watch?v=FdxvTcHJiA8 [Accessed 20 Oct 2024]
- Zotov, A (2018) Unity3D Android Gyroscope Controls (with a helicopter game) [online] Available at: https://www.youtube.com/watch?v=wpSm2O2LIRM [Accessed 20 Oct 2024]
- LearnWithYas (2024) How to move a 3D object using touch input ( x and y-axis ONLY ) - Unity Mobile [online] Available at: https://www.youtube.com/watch?v=YDSkiQDvYv8 [Accessed 20 Oct 2024]
- BMo (2020). 6 Minute PAUSE MENU Unity Tutorial. [online] Available at: https://www.youtube.com/watch?v=9dYDBomQpBQ. [Accessed 20 Oct 2024]
- Aakash, S (2022) Firebase Authentication In Unity [online] Available At: https://www.youtube.com/playlist?list=PL55AbeAhmmL_oCLGEqI-q5k_lOKrnBJTz [Accessed 1 January 2025]

### <ins> Frameworks And API:
- neogeek (2021) HapticFeedback [online] Available at: https://github.com/CandyCoded/HapticFeedback.git [Accessed 1 Jan 2025].
- Firebase (2024) Firebase [online] Available at: https://firebase.google.com/ [Accessed 1 January 2025]
- Implementing interstitial ads in Unity [online] Available at: https://docs.unity.com/ads/en-us/manual/ImplementingBasicAdsUnity [Accessed 1 January 2025]
- Implementing rewarded ads in Unity [online] Available at: https://docs.unity.com/ads/en-us/manual/ImplementingRewardedAdsUnity [Accessed 1 January 2025]

### <ins> Images/GUI:​

- Dankudraw, n.d. Wood texture background. [online] Available at: https://www.vecteezy.com/vector-art/2193057-wood-texture-background [Accessed 19 October 2024].​
- PNGimg, n.d. Chef PNG image with transparent background. [online] Available at: https://pngimg.com/image/38930 [Accessed 19 October 2024].​
- klyaksun, n.d. Old wooden boards with buttons and frames for game.  [online] Available at: https://www.vecteezy.com/vector-art/12996524-old-wooden-boards-with-buttons-and-frames-for-game [Accessed 19 October 2024].​
- vectortradition, n.d. Wooden buttons cartoon interface game UI elements. [online] Available at: https://www.vecteezy.com/vector-art/10876594-wooden-buttons-cartoon-interface-game-ui-elements [Accessed 19 October 2024].​
- arnikodetanto (2020) Food icon set. [online]  Available at: https://www.creativefabrica.com/product/food-icon-set/ [Accessed 19 October 2024].​
- zoetamago, n.d. restaurant eatery with wooden furniture graphic novel [online] Available at: https://www.vecteezy.com/photo/32492752-restaurant-eatery-with-wooden-furniture-graphic-novel-anime-manga-wallpaper [Accessed 19 October 2024].​
- freepik (2024) Flat vegetable and fruits background [online] Available at: https://www.freepik.com/premium-vector/flat-vegetable-fruits-background_4091987.htm [Accessed 1 Jan 2025]
- Michael, V (2017) Free Transparent PNG - Video Icon Free Download [online] Available at: https://freepngimg.com/png/30060-video-icon-free-download [Accessed 1 Jan 2025]

### <ins> Sound:
- creatorassets (2021) 8-Bit Coin Sound Effect (Copyright Free) [online] Available at: https://creatorassets.com/a/8-bit-coin-sound-effects [Accessed 1 January 2025]
- nickpanek620 (2024) Hopeful 8-Bit Instrumental [online] Available at: https://pixabay.com/music/video-games-hopeful-8-bit-instrumental-265101/ [Accessed 1 January 2025].

