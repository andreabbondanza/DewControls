# DEW CONTROLS

## About the controls
This is a set of controls (hope to expand it soon) for __UWP__ platform.  
I develop primarly on phone, desktop and tablet. Sincerely I don't know how these controls will approach on devices like __HoloLens__ or xbox-one.  
However, I will update the repository if I find news about this.

>For more information you can check the __inline__ documentation

## Helpers
In the namespace DewCommonLibrary you can find some helper and some converter.
Converters:
- BoolToVisibilityConverter
- VisibilityToBoolConverter
- DebugConverter
- ColorToNullableColor
- NullToVisibilityConverter

Helpers:
- AppSettings - An easy way to use localsettings

## Controls list
- Hamburger drawer
- Dialog Window
- Toast alerts
- Toast loader
- Float Button

### Work in progress
- Waffle menu

## Microsoft Community Toolkit
In this version I've removed AppStudio and I started to use Microsoft Community Toolkit.

## Hamburger
The Hamburger is __highly customizable__. You can check the customizable properties here.

### Properties
- HamburgerType: __enum__  
values:  LeftSide, LeftSideCompact, LeftSideCompactInLine, LeftSideInLine, RightSide, RightSideCompact, RightSideCompactInLine, RightSideInLine 
- HamburgerButtonAnimation: __enum__  
values:  No, ToArrow, ToVertical
- IsPaneOpeend: __bool__ - Get or set the value of panel (and open and close it)
- IsSwipeOpenEnabled: __bool__ - Get or set the value of "open with swipe" feature
- IsHamburgerButtonAnimationEnabled: __bool__ - Get or set the value for the "hamburger button animation feature"
- BarBackgroundColor: __Brush__ - The top bar background
- BarContent: __UIElement__ - The content of the top bar
- HamburgerForeground: __Brush__ - The hamburger button foreground
- HamburgerBackground: __Color__ - The hamburger button background color
- HamburgerBackgroundPressed: __Color__ - The hamburger button background color when pressed
- PaneBackground: __Brush__ - The panel background
- PaneContent: __UIElement__ - The panel content
- ContentBackground: __Brush__ - The main content background
- OpenedPaneLength: __double__ - The size of opened panel
- Content: __UIElement__ - The main content

### Events
- HamburgerTapped: __TappedEventHandler__ - Fired when hamburger button is tapped (not with swipe)
- PaneClosed: __TypedEventHandler<SplitView,Object>__ - Fired when panel is closed
- PaneClosing: __TypedEventHandler<SplitView,Object>__ - Fired when panel is closing

### Methods
There aren't public methods

### Example
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
### Some screens
<img src="http://andrewdev.eu/wp-content/uploads/2016/08/wp_ss_20160809_0002.png" width="200"/>
<img src="http://andrewdev.eu/wp-content/uploads/2016/08/wp_ss_20160809_0001.png" width="200"/>


## Toast popup
The toast popup is really cute and you can use it to give a feedback to the user about an operation, or obviously, whatever you want.

### Properties
- MessageFontFamily: __FontFamily__ - The font family for text in the toast  
- MessageFontSize: __double__ - The font size in the toast
- CornerRadius: __CornerRadius__ - The toast corners
- Background: __Brush__ - Toast background
- MessageForeground: __Brush__ - Toast text foreground
- Message: __string__ - The popup text
- IsVisible: __bool__ - Set or get the visibility property

### Events
There aren't Events

### Methods
- ShowPopupMessageAsync(__string__:The toast message ,__int__:Time to popup hide (in ms, 0 = infinite),__int__: Animation time (in ms)): __Task__ (awaitable)
- HidePopupMessageAsync(__int__: Animation time (in ms)): __Task__ (awaitable)

### Example
In view xaml (note: the z-index is your discrection)
```xaml
 <dc:DewToastPopup Margin="50" Background="WhiteSmoke" MessageFontSize="15" VerticalAlignment="Bottom" HorizontalAlignment="Center" x:Name="Popup" 
                          MessageForeground="Black"/>
```
In code behind
```c#
await Popup.ShowPopupMessageAsync("example", 2000);
```
### Some screens
<img src="http://andrewdev.eu/wp-content/uploads/2016/08/wp_ss_20160809_0003.png" width="200"/>


## Loader toast
This is a simple toast that contains a text and a loader ring. It's a simple way to show a loader with a message.

### Properties
- RingPosition: __enum__  
values:Top, Bottom  
- MessageFontFamily: __FontFamily__ - The font family for text in the toast  
- MessageFontSize: __double__ - The font size in the toast
- CornerRadius: __CornerRadius__ - The toast corners
- MessageForeground: __Brush__ - Toast text foreground
- Message: __string__ - The popup text
- Background: __Brush__ - Toast background
- IsRingEnabled: __bool__ - Set\get the ring abilitation
- IsRingActive: __bool__ - Set\get the ring activation
- IsVisible: __bool__ - Set or get the visibility property

### Events
There aren't Events

### Methods
- ShowPopupLoaderAsync(__int__:the animation time): __Task__ (awaitable)
- ShowPopupLoaderAsync(__string__:The message, __int__:the animation time): __Task__ (awaitable)
- HidePopupLoaderAsync(__int__:the animation time): __Task__ (awaitable)

### Example
In view xaml (note: the z-index is your discrection)
```xaml
 <dc:DewLoader Margin="50" Background="WhiteSmoke" MessageFontSize="15" VerticalAlignment="Bottom" HorizontalAlignment="Center" x:Name="Loader" 
                          MessageForeground="Black"/>
```
In code behind
```c#
await Loader.ShowPopupLoaderAsync("example", 2000);
```

## Dialog Window
Here we have a simple dialog control. You can customize it however you want.
The buttons must be defined in the buttons style properties.

### Properties
- DewDialogType: __enum__  
values: OnlyTopBar (no buttons are showed), TopBarWithButtons (complete dialog window), TopBarAcceptButton (top bar with only right button), Nothing (only content)
- DialogTitle: __string__ - Set\get the top bar text
- CloseGlyphForeground: __SolidColorBrush__ - The X button foreground
- TopBarBackground: __Brush__ - The top bar background
- TopBarForeground: __SolidColorBrush__ - The top bar foreground
- ContentBackground: __Brush__ - The content background
- Content: __UIElement__ - The content's content ( :| )
- ButtonAreaBackground: __Brush__ - The button area background
- LeftButtonStyle: __Style__ - Define the content and the button's style
- RightButtonStyle: __Style__ - Define the content and the button's style
- IsVisible: __bool__ - Set\get the control's visibility
- IsTopBarVisible: __bool__ - Set\get the top bar visibility
- IsButtonAreaVisibile: __bool__ - Set\get the buttons bar visibility
- IsLeftButtonVisible: __bool__ - Set\get the left button visibility

### Events
- LeftButtonTapped: __TappedEventHandler(object: Content,TappedRoutedEventArgs)__
- RightButtonTapped: __TappedEventHandler(object: Content ,TappedRoutedEventArgs)__
- CloseButtonTapped: __TappedEventHandler(object: Content ,TappedRoutedEventArgs)__
- DialogOpening: __OpenEventHandler(object: Content)__

### Methods
- ShowDialogAsync(__int__:the animation time): __Task__ (awaitable)
- HideDialogAsync(__int__:the animation time): __Task__ (awaitable)

### Example
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

### Some screens
<img src="http://andrewdev.eu/wp-content/uploads/2016/08/wp_ss_20160809_0004.png" width="200"/>

## Float Button
This control is similar to the button in Google Inbox App.
It's high customizable but also easy to use. I've used a mutual exclusion pattern to made this.
You have a default ListView in the DewFloatButton container for an immediate use, but you can also write in the DewFloatButton container whatever you want, let's see how.

### Custom stuff
The DewFloatButton control has a content control that can show whathever you want through the property __FloatButtonListView__ (don't be confused by name, the property is an UIElement and can be whatever you want, I've just used this name because the default use of DewFloatButton is with a ListView).
This property is in mutual exclusion with __FlyoutItemsSource__ where, if __FlyoutItemsSource__ is null the __FloatButtonListView__ is showed.

Es.
```xaml
<dc:DewFloatButton x:Name="FloatButton" 
                           Margin="10,10,20,30" VerticalAlignment="Bottom" Tapped="FloatButton_Tapped" 
                           DewFloatButtonBackground="#FF5AC350" 
                           DewFloatButtonClosed="FloatButton_FloatButtonClosed" 
                           DewFloatButtonOpened="FloatButton_FloatButtonOpened"                            
                           HorizontalAlignment="Right"                            
                           FlyoutWidth="250"
                           FlyoutMaxHeight="500">
            <dc:DewFloatButton.DewFloatButtonContent>
                <FontIcon Glyph="&#xE109;" Foreground="WhiteSmoke" ></FontIcon>
            </dc:DewFloatButton.DewFloatButtonContent>
            <dc:DewFloatButton.DewFloatButtonListView>
                <TextBlock>
                    Mmm, I want just a text in here
                </TextBlock>
            </dc:DewFloatButton.DewFloatButtonListView>
        </dc:DewFloatButton>
```
There are also a lot of properties that work with the default ListView and, obviously if you set them are unuseful if you user your stuff in __FloatButtonListView__.

### Work with default ListView
If you don't want spend much time working on a particular custom listview (or whatever you want) you can use the default ListView in __DewFloatButton__ control. You just need to bind the __FlyoutItemsSource__ to a collection of __DewFloatButtonItem__.
A __DewFloatButtonItem__ is an class that contains two properties, an event and a method:
- Icon: __UIElement__ - This field should be a graphic element like an icon, FontIcon, image, etc. Don't set it if you don't want show it.
- Text: __string__ - The item text
- OnSelected: __DewFloatButtonSelectedHandler(object, SelectionChangedEventArgs)__ - Selected item handler
- Selected: _void(object, SelectionChangedEventArgs)__ - Invoke the handler if you need

The __DewFloatButton__ ListView will be automatically populated.
The default ListView works in differents ways. You can set those ways through the __DewFloatButton__ properties for items.

Es.
```xaml
  <dc:DewFloatButton x:Name="FloatButton" 
                           Margin="10,10,20,30" VerticalAlignment="Bottom" Tapped="FloatButton_Tapped" 
                           DewFloatButtonBackground="#FF5AC350" 
                           DewFloatButtonClosed="FloatButton_FloatButtonClosed" 
                           DewFloatButtonOpened="FloatButton_FloatButtonOpened" 
                           SelectedEvidence="Yes" FlyoutItemsSource="{x:Bind ViewModel.DewItemsCollection, Mode=OneWay}"
                           CloseAfterSelect="Yes"
                           HorizontalAlignment="Right" 
                           ItemTextFontSize="22"
                           FlyoutWidth="250"
                           FlyoutMaxHeight="500"
                           ItemHeight="60"
                           ItemTextForeground="White"
                           ItemTextBackground="Transparent"
                           IsAnimationActive="True"
                           ItemTextHorizontalAlignment="Right"
                           >
            <dc:DewFloatButton.DewFloatButtonContent>
                <FontIcon Glyph="&#xE109;" Foreground="WhiteSmoke" ></FontIcon>
            </dc:DewFloatButton.DewFloatButtonContent>

        </dc:DewFloatButton>
```

### Properties
- CloseAfterSelectedEnum: __enum__  
values: Yes, No
- SelectedEvidenceEnum: __enum__  
values: Yes, No
- DewFloatbuttonListView: __UIElement__ - The container to show custom stuff
- DewFloatButtonContent: __UIElement__ - The content of DewFloatButton button
- DewFloatButtonBackground: __Brush__ - DewFloatButton button background
- FlyoutMaxHeight: __double__ - The max height for DewFloatButton container
- ItemTextFontSize: __double__ - The item text font size
- ItemTextFontFamily: __FontFamily__ - The item text font family
- ItemTextForeground: __Brush__ - The item text foreground
- ItemTextBackground: __Brush__ - The item text background
- ItemTextHorizontalAlignment: __HorizontalAlignment__ - The item text horizontal alignment
- ItemBackground: __Brush__ - The full item background
- FlyoutWidth: __double__ - The width of DewFloatButton container
- ItemHeight: __double__ - The item height
- FlyoutItemsSource: __ICollection\<DewFloatButtonItem>__ - The itemsource for default ListView
- ButtonStyle: __Style__ - A custom style for DewFloatButton
- FlyoutStyle: __Style__ - A custom style for flyout element (DewFloatButton container)
- IsAnimationActive: __bool__ - True if you want animation for DewFloatButton, false if not
- IsOpened: __bool__ - Return the state of DewFloatButton container
- SelectedEvidence: __SelectedEvidenceEnum__ - Indicates if an item selected should be highlighted
- CloseAfterSelect: __CloseAfterSelectedEnum__ - Indicates if DewFloatButton container must be closed after than an element has been selected


### Events
- Tapped: __TappedEventHandler(object: Content,TappedRoutedEventArgs)__
- DewFloatButtonClosed: __Action()__
- DewFloatButtonOpened: __Action()__

### Methods
- CloseFlyout(): __void__

### Example
See first section

### Some screens
<img src="http://andrewdev.eu/wp-content/uploads/2016/08/wp_ss_20160819_0003.png" width="200"/>
<img src="http://andrewdev.eu/wp-content/uploads/2016/08/wp_ss_20160819_0005.png" width="200"/>
<img src="http://andrewdev.eu/wp-content/uploads/2016/08/wp_ss_20160819_0004.png" width="200"/>

## List Selector

This is a simple control that show a list of item where you can check them.

### Properties

- CheckBoxBorderForeground: __SolidColorBrush__ - The checkbox border foreground
- ContainerBackground: __Bursh__ -  The container background
- Items: __ICollection\<DewListSelectorItem>__ - The list selector items
- SeparatorForeground: __SolidColorBrush__ - The item SeparatorForeground
- TextListForeground: __SolidColorBrush__ - The list items foreground
- TextTitleForeground: __SolidColorBrush__ - The title foreground
- TextTitle: __string__ - The title

### Events
- OnChecked: __TappedEventHandler__ - Fired after the item has changed value

### Example
```xaml
<tk:DropShadowPanel ShadowOpacity="1" BlurRadius="10" HorizontalAlignment="Center" VerticalAlignment="Center" OffsetX="0" OffsetY="0">
                    <dc:DewListSelector OnChecked="listsel_OnChecked" Width="300" Height="Auto" HorizontalAlignment="Center" TextListForeground="#FF303030" ContainerBackground="WhiteSmoke"
                                        SeparatorForeground="#FFC5C5C5"
                                        VerticalAlignment="Center" x:Name="listsel" TitleText="New point of view" TextTitleForeground="#FF0E0E0E" CheckBoxBorderForeground="#FF323232">
                    </dc:DewListSelector>
                </tk:DropShadowPanel>
```
### Some screens
<img src="http://andrewdev.eu/wp-content/uploads/2016/11/wp_ss_20161113_0001.png" width="200"/>

## Other sources

### See in action
You can see some of those controls in the [Photove App](https://www.microsoft.com/en-gb/store/p/photove/9nblggh4tl9n)

### Nuget
You can find controls on [nuget](https://www.nuget.org/packages/DewUserControls/)

### Some docs
[andrewdev](http://www.andrewdev.eu)

## Donation
[Help me to grow up, if you want](https://payPal.me/andreabbondanza)
