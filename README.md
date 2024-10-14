# Project Documentation for Unit Convertern

## Overview
This project contains a set of files related to a **Converter Application** in **.NET MAUI** that follows the **MVVM (Model-View-ViewModel)** pattern. The application consists of two primary views: a **Converter View** and a **Menu View**. Each of these views is implemented with separate XAML files for defining the user interface and corresponding ViewModels to handle the logic and data binding.

The key files included in this project are:
1. **ConverterView.xaml** - Defines the UI layout for the Converter.
2. **ConverterView.xaml.cs** - Code-behind for the `ConverterView`.
3. **ConverterViewModel.cs** - The ViewModel for `ConverterView` that handles data and commands.
4. **MenuView.xaml** - Defines the UI layout for the Menu.
5. **MenuView.xaml.cs** - Code-behind for the `MenuView`.
6. **MenuViewModel.cs** - The ViewModel for `MenuView` that manages data and commands.

## Overview of the UI Flow
### Screen 1: Basic UI Layout

<img width="462" alt="Basic UI" src="https://github.com/user-attachments/assets/6504e052-e3ab-492e-b94b-1e7c08cf44f4">

### Screen 2: Unit Converter
<img width="462" alt="Length cm-inch" src="https://github.com/user-attachments/assets/51d34995-3f43-4353-ad1b-197939c95478">

### Screen 3: Unit - Length Options
<img width="462" alt="Length Options" src="https://github.com/user-attachments/assets/562db591-c522-421d-aee0-3b9847370a0f">


# Code Analysis
### 1. ConverterView.xaml

#### 1. Page Structure
The root element of this XAML file is typically a `<ContentPage>` or another suitable container such as a `<Grid>` or `<StackLayout>`. It is used to organize all of the UI elements required for the converter view.

- **Namespaces**: The file includes several namespaces such as:
  - `xmlns="http://schemas.microsoft.com/dotnet/2021/maui"` - The primary namespace for .NET MAUI elements.
  - `xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"` - Defines common XAML elements like data binding.

#### 2. StackLayout
The **layout structure** of the view is typically organized using `StackLayout`. The `StackLayout` control allows vertical or horizontal stacking of its child elements.
- In this case, `StackLayout` is often used to vertically organize the elements such as:
  - **Entry (Input field)**
  - **ComboBox or Picker (Unit selection)**
  - **Button (Conversion trigger)**
  - **Label (Display result)**

#### 3. UI Elements
Below are some of the main UI components that can be found in the `ConverterView.xaml` file:

- **Entry**: The `<Entry>` control is used for accepting input from the user. Typically, this field is where the user inputs the value to be converted.
  ```xaml
  <Entry x:Name="InputValueEntry" Placeholder="Enter value to convert" />
  ```
  - **Placeholder**: Provides a hint to the user about what type of input is expected (e.g., "Enter value to convert").

- **ComboBox or Picker**: The `<Picker>` or `<ComboBox>` control allows users to select the units they want to convert from and to. For example, converting from **Inches** to **Centimeters**.
  ```xaml
  <Picker x:Name="UnitSelectionPicker" Title="Select Unit" />
  ```
  - **ItemsSource**: In most cases, the items for this control are defined in the `ViewModel` and are bound to this picker using data binding.

- **Button**: A `<Button>` element is used to initiate the conversion operation. When clicked, this button is usually bound to a command from the `ViewModel`.
  ```xaml
  <Button Text="Convert" Command="{Binding ConvertCommand}" />
  ```
  - **Command Binding**: The `ConvertCommand` is defined in the `ConverterViewModel` and contains the logic for converting the units. This follows the **MVVM (Model-View-ViewModel)** pattern, promoting clean code separation.

- **Label**: The `<Label>` control is used to display the conversion result. The `Text` property is usually bound to a property in the `ViewModel`, which gets updated after a successful conversion.
  ```xaml
  <Label Text="{Binding ConversionResult}" FontSize="Large" />
  ```
  - **Binding**: The `ConversionResult` is a property in the `ViewModel` that holds the output value.

#### 4. Layout Example
An example structure of the `ConverterView.xaml` layout may look like this:

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="YourNamespace.ConverterView">
    <StackLayout Padding="20">
        <!-- User input field -->
        <Entry x:Name="InputValueEntry" Placeholder="Enter value to convert" />
        
        <!-- Unit selection dropdown -->
        <Picker x:Name="UnitSelectionPicker" Title="Select Unit" />
        
        <!-- Convert button -->
        <Button Text="Convert" Command="{Binding ConvertCommand}" />
        
        <!-- Conversion result display -->
        <Label Text="{Binding ConversionResult}" FontSize="Large" />
    </StackLayout>
</ContentPage>
```

#### Binding and MVVM Pattern
This `ConverterView` follows the **MVVM pattern**, which helps maintain a clear separation between the UI (View) and the data/logic (ViewModel).

- **BindingContext**: The `BindingContext` is typically set in the code-behind file (`ConverterView.xaml.cs`), connecting the `ViewModel` to the `View`. This allows controls in the XAML to bind to properties and commands defined in the `ViewModel`.
  ```csharp
  public partial class ConverterView : ContentPage
  {
      public ConverterView()
      {
          InitializeComponent();
          BindingContext = new ConverterViewModel();
      }
  }
  ```

- **Data Binding**: The `Entry`, `Picker`, `Button`, and `Label` controls are all bound to properties and commands in the `ViewModel`, ensuring that the UI is updated whenever the data changes. For example, the `ConvertCommand` is executed when the button is clicked, which updates the `ConversionResult` property, automatically reflected in the `Label`.

#### Conclusion
The `ConverterView.xaml` defines the essential user interface components for the **unit conversion** functionality of the application. By using **MVVM**, it ensures a clean separation between the UI and the underlying data logic, promoting easier maintenance and scalability.

The key features of the `ConverterView` include:
- User-friendly layout with `Entry`, `Picker`, and `Label` for input and output.
- Use of **commands** and **data binding** to handle user interactions seamlessly.
- Following the **MVVM pattern** for better code organization.


### 2. ConverterView.xaml.cs

#### Key Responsibilities
The main responsibilities of `ConverterView.xaml.cs` are as follows:
- **Initialize the UI Components**: Load and prepare the UI elements defined in `ConverterView.xaml`.
- **Bind the ViewModel**: Set the `BindingContext` to the appropriate **ViewModel** (`ConverterViewModel`) to ensure data binding between UI elements and business logic.
- **Event Handling**: If any additional UI events (e.g., button clicks) require handling beyond what's defined in the ViewModel, they would be handled here.


#### 1. Namespace Declarations
The code-behind file typically imports necessary namespaces for working with **MAUI**, **UI components**, and **MVVM bindings**:

```csharp
using System;
using Microsoft.Maui.Controls;
```
- **System**: Provides base class definitions, including those for common data types and event handling.
- **Microsoft.Maui.Controls**: Contains the essential classes for working with UI elements in MAUI, such as `ContentPage` and `BindingContext`.

#### 2. Constructor
The `ConverterView.xaml.cs` file contains a **constructor** that is called when the `ConverterView` is instantiated. The constructor is responsible for initializing the UI components and setting up data binding.

```csharp
public partial class ConverterView : ContentPage
{
    public ConverterView()
    {
        InitializeComponent();
        BindingContext = new ConverterViewModel();
    }
}
```
- **InitializeComponent()**: This method is generated by the XAML file and is called to initialize all of the UI components defined in `ConverterView.xaml`. It ensures that all XAML components are loaded and ready for use.
- **BindingContext = new ConverterViewModel()**: This line sets the `BindingContext` of the page to an instance of `ConverterViewModel`. By establishing this binding context, the UI controls defined in XAML can bind to properties and commands in the ViewModel, facilitating a connection between the UI and business logic.

#### 3. MVVM Binding Context
The **MVVM pattern** is an essential part of .NET MAUI applications. By setting the `BindingContext` in the code-behind, the UI defined in the `ConverterView` can easily bind to the **properties** and **commands** in `ConverterViewModel`. This allows for the **separation of concerns**, ensuring that the UI does not directly manage data or business logic, which improves code maintainability.

**Example**:
- The `Button` in the XAML may be bound to a command called `ConvertCommand` from the `ConverterViewModel`. When the user interacts with the button, the command is triggered in the ViewModel, which carries out the appropriate logic (such as converting units).

#### 4. Event Handling (Optional)
Though the focus in MAUI and the MVVM pattern is to handle events through commands defined in the **ViewModel**, there are times when you might need to implement some **event handlers** in the code-behind.
For example, if you need a custom initialization logic that is not suitable for the ViewModel, you would implement it in the constructor or define additional methods in the code-behind.

```csharp
private void OnPageAppearing(object sender, EventArgs e)
{
    // Example of custom logic on page appearing
    Console.WriteLine("Page is appearing");
}
```

In this scenario, you could attach this event handler to the `Appearing` event of the page to execute some specific logic when the page appears.

### Typical Structure of ConverterView.xaml.cs
The structure of a typical code-behind file includes:
- **Namespace declaration**
- **Class definition** extending `ContentPage`
- **Constructor** to initialize the page and set the `BindingContext`
- Any additional **event handlers** if needed.

```csharp
using System;
using Microsoft.Maui.Controls;

namespace YourNamespace
{
    public partial class ConverterView : ContentPage
    {
        public ConverterView()
        {
            InitializeComponent();
            BindingContext = new ConverterViewModel();
        }

        // Optional: Custom event handlers can be added here
        private void OnPageAppearing(object sender, EventArgs e)
        {
            // Custom logic
        }
    }
}
```

#### Summary Table of Key Elements
| Component                 | Description                                            |
|---------------------------|--------------------------------------------------------|
| **Namespace Declarations** | Imports required libraries for working with MAUI.       |
| **InitializeComponent()**  | Initializes all UI components defined in XAML.         |
| **BindingContext**         | Sets the data context to the ViewModel for data binding.|
| **Event Handling**         | (Optional) Custom event logic for specific UI events.   |


### 3. ConverterViewModel.cs



#### Key Responsibilities
The `ConverterViewModel` handles the following responsibilities:
- **Data Binding**: Exposes properties to bind with the **ConverterView**.
- **Conversion Logic**: Contains the core logic to convert units based on user input.
- **Commands**: Handles user actions (such as clicking a button) through **commands** bound to the UI.
- **Property Change Notifications**: Implements mechanisms to notify the UI of any changes in data.

#### 1. Namespace Declarations
The ViewModel imports necessary namespaces required for data binding and command handling:

```csharp
using System;
using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;
```
- **System.ComponentModel**: Provides support for **INotifyPropertyChanged** to implement property change notifications.
- **System.Windows.Input**: Supports commands such as `ICommand` for handling user interactions.
- **Microsoft.Maui.Controls**: Provides necessary classes like `Command`.

#### 2. Implementing INotifyPropertyChanged
The `ConverterViewModel` implements the **INotifyPropertyChanged** interface. This interface is used to **notify the UI** whenever a property value changes, ensuring that the UI is updated automatically.

```csharp
public class ConverterViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
```
- **PropertyChanged Event**: Declares an event that is raised when a property value changes.
- **OnPropertyChanged() Method**: Used to raise the `PropertyChanged` event for a given property, allowing the UI to refresh when data changes.

#### 3. Properties
The `ConverterViewModel` exposes properties that bind to the controls in the **ConverterView**. These properties include user input, selected unit, and conversion results.

#### Example Properties
```csharp
private double inputValue;
public double InputValue
{
    get => inputValue;
    set
    {
        if (inputValue != value)
        {
            inputValue = value;
            OnPropertyChanged(nameof(InputValue));
        }
    }
}

private string conversionResult;
public string ConversionResult
{
    get => conversionResult;
    set
    {
        if (conversionResult != value)
        {
            conversionResult = value;
            OnPropertyChanged(nameof(ConversionResult));
        }
    }
}
```
- **InputValue**: Represents the value entered by the user to be converted.
- **ConversionResult**: Stores the output after performing the conversion.
- Both properties call `OnPropertyChanged()` to notify the UI of any changes.

#### 4. Commands
Commands are essential in the **MVVM pattern** for handling user actions without using code-behind. In `ConverterViewModel`, commands are used to trigger the conversion logic when the user interacts with the UI.

#### ConvertCommand Example
```csharp
public ICommand ConvertCommand { get; }

public ConverterViewModel()
{
    ConvertCommand = new Command(OnConvert);
}

private void OnConvert()
{
    // Conversion logic implementation
    ConversionResult = "Conversion result based on input and unit";
}
```
- **ConvertCommand**: This command is bound to the **Convert Button** in the `ConverterView.xaml`. When the button is clicked, it triggers the `OnConvert()` method.
- **OnConvert() Method**: Contains the core logic for converting the input value based on the selected unit. After performing the conversion, the result is assigned to the `ConversionResult` property, which in turn updates the UI.

#### 5. Constructor
The constructor of `ConverterViewModel` initializes any properties or commands that need to be available as soon as the ViewModel is created.

```csharp
public ConverterViewModel()
{
    ConvertCommand = new Command(OnConvert);
}
```
- **ConvertCommand Initialization**: Creates an instance of the `ConvertCommand` and associates it with the `OnConvert` method. This ensures that when the user presses the **Convert Button**, the appropriate logic is executed.

#### Summary Table of Key Elements
| Component                  | Description                                            |
|----------------------------|--------------------------------------------------------|
| **INotifyPropertyChanged** | Interface to notify the UI about property changes.     |
| **InputValue Property**    | Holds the value input by the user for conversion.      |
| **ConvertCommand**         | Command triggered to perform the conversion.           |
| **OnConvert() Method**     | Contains the logic for converting the input value.     |
| **BindingContext**         | Connects the ViewModel to the View for data binding.   |


### 4. MenuView.xaml

#### Key Components
The `MenuView.xaml` file is responsible for defining the layout of the **Menu Screen** using **XAML**. Below, we will discuss the various UI elements used and how they contribute to the functionality of the menu.

#### 1. Page Structure
The root element of the `MenuView.xaml` is typically a `<ContentPage>` or similar container that allows for the organization of child elements. In this case, the `ContentPage` acts as the container for the entire Menu View.

- **Namespaces**: The file includes necessary namespaces such as:
  - `xmlns="http://schemas.microsoft.com/dotnet/2021/maui"` - The primary namespace for .NET MAUI elements.
  - `xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"` - Defines common XAML elements and behaviors.

#### 2. Layout Controls
The layout structure is generally organized using controls such as **StackLayout** or **Grid**, which help to arrange the different menu items in an intuitive manner.

- **StackLayout**: Often used to organize items vertically or horizontally.
- **Grid**: If used, helps create a more flexible layout with rows and columns for organizing multiple elements.

#### 3. UI Elements
The following are the key UI components present in the `MenuView.xaml` file:

##### 3.1 Buttons or ImageButtons for Navigation
The main purpose of the `MenuView` is to provide navigation options to the user. This is often achieved using **Button** or **ImageButton** elements, which represent different types of converters or sections of the app.

- **ImageButton**: In some cases, `ImageButton` elements are used to provide a more visually appealing interface by using images for each navigation button.

Example of an ImageButton:
```xaml
<ImageButton Source="length_icon.png" Command="{Binding NavigateToLengthConverterCommand}" />
```
- **Source**: Specifies the image file to use for the button.
- **Command Binding**: The `Command` property is bound to a command in the `MenuViewModel`. For instance, `NavigateToLengthConverterCommand` handles the navigation logic to the **Length Converter**.

##### 3.2 Labels for Descriptions
**Labels** are used alongside buttons or images to indicate what each button does or to give a description of each option available to the user.

Example of a Label:
```xaml
<Label Text="Length Converter" HorizontalOptions="Center" />
```
- **Text**: Describes the functionality or feature (e.g., "Length Converter").
- **HorizontalOptions**: Aligns the text within the layout.

#### 4. Layout Example
The following is an example structure of the `MenuView.xaml` layout:

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="YourNamespace.MenuView">
    <StackLayout Padding="20">
        <!-- Length Converter -->
        <ImageButton Source="length_icon.png" Command="{Binding NavigateToLengthConverterCommand}" />
        <Label Text="Length Converter" HorizontalOptions="Center" />

        <!-- Temperature Converter -->
        <ImageButton Source="temperature_icon.png" Command="{Binding NavigateToTemperatureConverterCommand}" />
        <Label Text="Temperature Converter" HorizontalOptions="Center" />
    </StackLayout>
</ContentPage>
```
- **StackLayout**: Arranges the buttons and labels in a vertical layout.
- **ImageButton and Label pairs**: Each pair represents a feature or a converter that the user can select.

#### 5. Binding and MVVM Pattern
The `MenuView` follows the **MVVM** pattern by binding commands from the `MenuViewModel` to UI components, which allows for clean separation of logic from UI presentation.

- **Command Binding**: Each button or navigation element is bound to a command in the `MenuViewModel`. This approach ensures that the **ViewModel** handles the logic while the **View** is only concerned with displaying the UI.
  - Example: The `NavigateToLengthConverterCommand` command in the `ViewModel` is executed when the **ImageButton** is pressed, which triggers navigation to the **Length Converter** page.
 
#### 6. Grid GestureRecognizers in .NET MAUI

#### Key Features
- **Gesture Handling**: Allows for detecting gestures like taps, swipes, pinch, and pan.
- **Declarative XAML Approach**: Gesture recognizers can be added directly within the XAML code for easy integration with the UI.
- **Supports Multiple Gesture Types**: `.NET MAUI` supports several types of gestures, such as tap, swipe, and pinch.

#### Types of Gesture Recognizers
- **TapGestureRecognizer**: Detects a tap gesture.
- **SwipeGestureRecognizer**: Detects a swipe in one of the four cardinal directions (left, right, up, down).
- **PinchGestureRecognizer**: Detects pinch gestures, typically used for zooming in or out.
- **PanGestureRecognizer**: Detects pan gestures, typically for dragging an element across the screen.

##### Example Usage
Below is a detailed example of how `<Grid.GestureRecognizers>` can be implemented in `.NET MAUI` to handle user interactions like tapping on a grid element.

```xml
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="YourNamespace.MainPage">
    <Grid BackgroundColor="LightGray" Padding="20">
        <Grid.GestureRecognizers>
            <TapGestureRecognizer Command="{Binding OnGridTappedCommand}" NumberOfTapsRequired="1" />
        </Grid.GestureRecognizers>
        
        <Label Text="Tap anywhere on the grid"
               HorizontalOptions="Center"
               VerticalOptions="Center"
               FontSize="Large" />
    </Grid>
</ContentPage>
```
##### Explanation
- **Grid**: A container that organizes content into rows and columns.
- **Grid.GestureRecognizers**: This element allows adding gesture recognition capabilities to the Grid.
- **TapGestureRecognizer**: In this example, it listens for a tap gesture on the grid.
  - **Command**: The `Command` property binds to a command in the ViewModel (`OnGridTappedCommand`), which handles the action to be performed when the grid is tapped.
  - **NumberOfTapsRequired**: Specifies the number of taps required to trigger the command (in this case, one tap).

##### Command in ViewModel Example
```csharp
public class MainPageViewModel
{
    public ICommand OnGridTappedCommand { get; }

    public MainPageViewModel()
    {
        OnGridTappedCommand = new Command(OnGridTapped);
    }

    private void OnGridTapped()
    {
        // Logic to execute when the grid is tapped
        Console.WriteLine("Grid was tapped!");
    }
}
```
- **OnGridTappedCommand**: This command is executed when the grid is tapped. It is bound to the `TapGestureRecognizer` in the XAML.
- **OnGridTapped Method**: Contains the logic that should be performed when the gesture is detected.

#### Summary Table of Key Elements
| Component                  | Description                                      |
|----------------------------|--------------------------------------------------|
| **Grid.GestureRecognizers**| Enables gesture detection on a Grid layout.     |
| **TapGestureRecognizer**   | Detects tap gestures, executes commands.        |
| **Command**                | Binds gesture recognizer to ViewModel logic.    |
| **NumberOfTapsRequired**   | Specifies the number of taps required to trigger the command. |



#### Summary Table of Components
| Component             | File Path                | Description                                  | Key Features                            |
|-----------------------|--------------------------|----------------------------------------------|-----------------------------------------|
| **Converter View**    | ConverterView.xaml       | UI for the Converter section                 | TextBox, ComboBox, Button, Label        |
| **Converter Code-Behind** | ConverterView.xaml.cs  | Initializes the Converter View               | Binds to `ConverterViewModel`           |
| **Converter ViewModel** | ConverterViewModel.cs   | Handles logic and commands for conversion    | Input properties, `ConvertCommand`      |
| **Menu View**         | MenuView.xaml            | UI for the main menu                         | Button for navigation                   |
| **Menu Code-Behind**  | MenuView.xaml.cs         | Initializes the Menu View                    | Binds to `MenuViewModel`                |
| **Menu ViewModel**    | MenuViewModel.cs         | Manages navigation commands                  | `NavigateToConverterCommand`            |

## Reference Sites
- [.NET MAUI Documentation](https://learn.microsoft.com/en-us/dotnet/maui/)
- [Microsoft Learn - MVVM Pattern](https://learn.microsoft.com/en-us/xamarin/xamarin-forms/enterprise-application-patterns/mvvm)
- [Navigation in .NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/navigation](https://learn.microsoft.com/en-us/dotnet/maui/user-interface/pages/navigationpage?view=net-maui-8.0))

## Required Nuget
- PropertyChanged.Fody : Version 4.1.0  /  Author : Simon Cropp
- UnitsNet : Version 6.0.0-pre012  /  Author : Andreas Gullberg Larsen 
