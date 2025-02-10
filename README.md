**To access core package, see Packages/com.aj_libraries.pixelperfect**
-


This is a simple adaptation of the Pixel Perfect camera supplied in Unity 2D.
-

The goal of this project was to address multiple issues which surround the pixel perfect camera.
- Due to the nature of pixel art, any attempts to scale pixel art up and down will damage the integrity of the artwork if not done correctly.
- The pixel perfect camera, if cropped and not stretched, will create a large black border around the remaining area. This is not appealing.
- The border is created by the pixel perfect camera attempting to scale the viewport to the largest integer factor it can without clipping. The remaining area on the screen is filled in with black.
  We do not know the user's screen size, so there is a possibility that the viewport will be far too small for some users.
- UI is not well suited for the pixel perfect camera.
- If a user's screen size changes, the game cannot update to meet this change.
- Differences between the normal Pixel Perfect camera, and URP Pixel Perfect camera

My Improvements
-
- Create multiple resolutions for the pixel viewport. This will allow Unity to choose which resolution is correct for any users screensize, choosing the biggest viewport.
- Get rid of the black border by creating a new type of Pixel Perfect camera, which does not clear to black before drawing the viewport.
- Demonstration of UI
- Allow other areas of the game to know what the current resolution is, and make changes if necessary
- Create multiple cameras for the border, world view, and UI
- Update if the screen size changes
- Preprocessor definitions for either the built in Pixel Perfect camera, or URP pixel perfect camera.
