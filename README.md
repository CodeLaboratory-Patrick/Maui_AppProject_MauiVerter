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


## Code Analysis
### 1. ConverterView.xaml

### 2. ConverterView.xaml.cs

### 3. ConverterViewModel.cs

### 4. MenuView.xaml

### 5. MenuView.xaml.cs

### 6. MenuViewModel.cs

## Summary Table of Components
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
- [Navigation in .NET MAUI](https://learn.microsoft.com/en-us/dotnet/maui/fundamentals/navigation)
