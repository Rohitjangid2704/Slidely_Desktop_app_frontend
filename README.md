# Slidely Desktop App Frontend

This is the frontend for the Slidely Desktop App, created using Visual Basic in Visual Studio. The app allows users to create and view submissions, with a built-in stopwatch feature.

## Screenshots

### Main Form
![Main Form](https://github.com/yourusername/Slidely_Desktop_app_frontend/raw/main/screenshots/main_form.png)

### Create New Submission Form
![Create New Submission Form](https://github.com/yourusername/Slidely_Desktop_app_frontend/raw/main/screenshots/create_submission_form.png)

### View Submissions Form
![View Submissions Form](https://github.com/yourusername/Slidely_Desktop_app_frontend/raw/main/screenshots/view_submissions_form.png)

## Getting Started

### Prerequisites

- Windows OS
- Visual Studio with Visual Basic support

### Installation

1. **Clone the repository to your local machine:**
   ```sh
   git clone https://github.com/yourusername/Slidely_Desktop_app_frontend.git
   ```

2. **Open the project in Visual Studio:**
   - Open Visual Studio.
   - Select `File` -> `Open` -> `Project/Solution`.
   - Navigate to the cloned repository and select the `.sln` file.

3. **Build and run the project:**
   - Click on `Build` -> `Build Solution`.
   - Start the application by clicking on `Debug` -> `Start Debugging`.

## Usage

### Creating a New Submission

1. Click the "Create New Submission" button.
2. Fill out the form with your Name, Email, Phone Number, and GitHub repo link.
3. Use the stopwatch to track the time spent on the form.
4. Press `Ctrl + S` to submit the form.

### Viewing Submissions

1. Click the "View Submissions" button.
2. Use the "Previous" and "Next" buttons to navigate through the submissions.

## Backend Server

The frontend communicates with a backend server to save and retrieve submissions. The backend server is built using Express and TypeScript, and it uses a JSON file as a database.

### Backend Endpoints

- **/ping:** A GET request that always returns True.
- **/submit:** A POST request with parameters `name`, `email`, `phone`, `github_link`, and `stopwatch_time`.
- **/read:** A GET request with query parameter `index` which is a 0-index for reading the (index+1)th form submission.

## License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.
```
