#DEW CONTROLS

##About the controls
This is a set of controls (hope to expand it soon) for __UWP__ platform.  
I develop primarly on phone, desktop and tablet. Sincerely I don't know how these controls will approach on devices like __HoloLens__ or xbox-one.  
However, I will update the repository if I find news about this.

>For more information you can check the __inline__ documentation

##Controls list
- Hamburger drawer
- Dialog Window
- Toast alerts
- Toast loader

###Work in progress
- Waffle menu
- Floating button (like google inbox)

##AppStudio
Before the appstudio release, I wrote a library for animations, etc. After AppStudio release, I've updated this library with it.
Now the library contains helpers and other stuff like converters.

##Hamburger
The Hamburger is __highly customizable__. You can check the customizable properties here.

###Properties
- HamburgerType:__enum__  
values:  LeftSide, LeftSideCompact, LeftSideCompactInLine, LeftSideInLine, RightSide, RightSideCompact, RightSideCompactInLine, RightSideInLine 
- HamburgerButtonAnimation:__enum__  
values:  No, ToArrow, ToVertical
- IsPaneOpeend:__bool__ - Get or set the value of panel (and open and close it)
- IsSwipeOpenEnabled:__bool__ - Get or set the value of "open with swipe" feature
- IsHamburgerButtonAnimationEnabled:__bool__ - Get or set the value for the "hamburger button animation feature"
- BarBackgroundColor:__Brush__ - The top bar background
- BarContent:__UIElement__ - The content of the top bar
- HamburgerForeground:__Brush__ - The hamburger button foreground
- HamburgerBackground:__Color__ - The hamburger button background color
- HamburgerBackgroundPressed:__Color__ - The hamburger button background color when pressed
- PaneBackground:__Brush__ - The panel background
- PaneContent:__UIElement__ - The panel content
- ContentBackground:__Brush__ - The main content background
- OpenedPaneLength:__double__ - The size of opened panel
- Content:__UIElement__ - The main content

###Events
- HamburgerTapped:__TappedEventHandler__ - Fired when hamburger button is tapped (not with swipe)
- PaneClosed:__TypedEventHandler<SplitView,Object>__ - Fired when panel is closed
- PaneClosing:__TypedEventHandler<SplitView,Object>__ - Fired when panel is closing

###Methods
There aren't public methods

###Example
```xaml
<dc:DewHamburgerMenu x:Name="MainMenu"  
    BarBackgroundColor="Transparent"   
    ContentBackground="Transparent"   
    PaneBackground="Transparent"   
    HamburgerType="LeftSideCompact">    
    <dc:DewHamburgerMenu.PaneContent>  
            <!-- pane stuff -->  
    </dc:DewHamburgerMenu.PaneContent>  
    <dc:DewHamburgerMenu.BarContent>  
            <TextBlock Text="" x:Name="HamburgerTitle" FontSize="28" VerticalAlignment="Center" HorizontalAlignment="Center" Foreground="WhiteSmoke" Margin="0,0,30,0"/>  
    </dc:DewHamburgerMenu.BarContent>  
    <dc:DewHamburgerMenu.Content>  
        <Grid>  
            <Frame x:Name="PageFrame"  /> 
        </Grid>  
    </dc:DewHamburgerMenu.Content>  
</dc:DewHamburgerMenu>
```
###Some screen
<img src="http://andrewdev.eu/wp-content/uploads/2016/08/wp_ss_20160809_0002.png" width="200"/>
<img src="http://andrewdev.eu/wp-content/uploads/2016/08/wp_ss_20160809_0001.png" width="200"/>


##Toast popup
The toast popup is really cute and you can use it to give a feedback to the user about an operation, or obviously, whatever you want.

###Properties
- MessageFontFamily:__FontFamily__ - The font family for text in the toast  
- MessageFontSize:__double__ - The font size in the toast
- CornerRadius:__CornerRadius__ - The toast corners
- Background:__Brush__ - Toast background
- MessageForeground:__Brush__ - Toast text foreground
- Message:__string__ - The popup text
- IsVisible:__bool__ - Set or get the visibility property

###Events
There aren't Events

###Methods
- ShowPopupMessageAsync(__string__:The toast message ,__int__:Time to popup hide (in ms, 0 = infinite),__int__: Animation time (in ms)):__Task__ (awaitable)
- HidePopupMessageAsync(__int__: Animation time (in ms)):__Task__ (awaitable)

###Example
In view xaml (note: the z-index is your discrection)
```xaml
 <dc:DewToastPopup Margin="50" Background="WhiteSmoke" MessageFontSize="15" VerticalAlignment="Bottom" HorizontalAlignment="Center" x:Name="Popup" 
                          MessageForeground="Black"/>
```
In code behind
```c#
await Popup.ShowPopupMessageAsync("example", 2000);
```
###Some screen
<img src="http://andrewdev.eu/wp-content/uploads/2016/08/wp_ss_20160809_0003.png" width="200"/>


##Loader toast
This is a simple toast that contains a text and a loader ring. It's a simple way to show a loader with a message.

###Properties
- RingPosition:__enum__  
values:Top, Bottom  
- MessageFontFamily:__FontFamily__ - The font family for text in the toast  
- MessageFontSize:__double__ - The font size in the toast
- CornerRadius:__CornerRadius__ - The toast corners
- MessageForeground:__Brush__ - Toast text foreground
- Message:__string__ - The popup text
- Background:__Brush__ - Toast background
- IsRingEnabled:__bool__ - Set\get the ring abilitation
- IsRingActive:__bool__ - Set\get the ring activation
- IsVisible:__bool__ - Set or get the visibility property

###Events
There aren't Events

###Methods
- ShowPopupLoaderAsync(__int__:the animation time):__Task__ (awaitable)
- ShowPopupLoaderAsync(__string__:The message, __int__:the animation time):__Task__ (awaitable)
- HidePopupLoaderAsync(__int__:the animation time):__Task__ (awaitable)

###Example
In view xaml (note: the z-index is your discrection)
```xaml
 <dc:DewLoader Margin="50" Background="WhiteSmoke" MessageFontSize="15" VerticalAlignment="Bottom" HorizontalAlignment="Center" x:Name="Loader" 
                          MessageForeground="Black"/>
```
In code behind
```c#
await Loader.ShowPopupLoaderAsync("example", 2000);
```

##Dialog Window
Here we have a simple dialog control. You can customize it however you want.
The buttons must be defined in the buttons style properties.

###Properties
- DewDialogType:__enum__  
values: OnlyTopBar (no buttons are showed), TopBarWithButtons (complete dialog window), TopBarAcceptButton (top bar with only right button), Nothing (only content)
- DialogTitle:__string__ - Set\get the top bar text
- CloseGlyphForeground:__SolidColorBrush__ - The X button foreground
- TopBarBackground:__Brush__ - The top bar background
- TopBarForeground:__SolidColorBrush__ - The top bar foreground
- ContentBackground:__Brush__ - The content background
- Content:__UIElement__ - The content's content ( :| )
- ButtonAreaBackground:__Brush__ - The button area background
- LeftButtonStyle:__Style__ - Define the content and the button's style
- RightButtonStyle:__Style__ - Define the content and the button's style
- IsVisible:__bool__ - Set\get the control's visibility
- IsTopBarVisible:__bool__ - Set\get the top bar visibility
- IsButtonAreaVisibile:__bool__ - Set\get the buttons bar visibility
- IsLeftButtonVisible:__bool__ - Set\get the left button visibility

###Events
- LeftButtonTapped:__TappedEventHandler(object: Content,TappedRoutedEventArgs)__
- RightButtonTapped:__TappedEventHandler(object: Content ,TappedRoutedEventArgs)__
- CloseButtonTapped:__TappedEventHandler(object: Content ,TappedRoutedEventArgs)__
- DialogOpening: __OpenEventHandler(object: Content)__

###Methods
- ShowDialogAsync(__int__:the animation time):__Task__ (awaitable)
- HideDialogAsync(__int__:the animation time):__Task__ (awaitable)

###Example
In view xaml (note: the z-index is your discrection)
```xaml
 <dc:DewDialog DialogType="TopBarWithButtons" x:Name="Dialog" ContentBackground="#cc000000" TopBarBackground="Transparent" 
                          ButtonAreaBackground="Transparent" DialogOpening="Dialog_DialogOpening"
                      RightButtonTapped="Dialog_RightButtonTapped"
                          LeftButtonTapped="Dialog_LeftButtonTapped"
                      CloseGlyphForeground="White" IsVisible="False">
              <!-- content stuff -->

                <dc:DewDialog.RightButtonStyle>
                    <Style TargetType="Button" BasedOn="{StaticResource UWButtonLayer}">
                        <Setter Property="Content">
                            <Setter.Value>
                                <TextBlock Text="" x:Uid="CreateCollectionButton"></TextBlock>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </dc:DewDialog.RightButtonStyle>
                <dc:DewDialog.LeftButtonStyle>
                    <Style TargetType="Button" BasedOn="{StaticResource UWButtonLayer}">
                        <Setter Property="Content">
                            <Setter.Value>
                                <TextBlock Text="" x:Uid="CancelButton"></TextBlock>
                            </Setter.Value>
                        </Setter>
                    </Style>
                </dc:DewDialog.LeftButtonStyle>
            </dc:DewDialog>
```
In code behind
```c#
await Loader.ShowDialogAsync(500);
```

###Some screen
<img src="http://andrewdev.eu/wp-content/uploads/2016/08/wp_ss_20160809_0004.png" width="200"/>


##Other sources

###See in action
You can see some of those controls in the [Photove App](https://www.microsoft.com/en-gb/store/p/photove/9nblggh4tl9n)

###Nuget
You can find controls on [nuget](https://www.nuget.org/packages/DewUserControls/)
