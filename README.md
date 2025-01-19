# Pert-diagram-maker

![.NET](https://img.shields.io/badge/.NET-8-blue)
![GitHub](https://img.shields.io/github/license/gamalmouhssine/Pert-diagram-maker)

A web-based **Pert-diagram-maker** built with **ASP.NET Core 8** to help project managers visualize task dependencies, calculate critical paths, and estimate project timelines. This tool uses **Mermaid.js** to render interactive PERT charts, making it easy to understand complex project workflows.

---

## Features

- **Task Management**:
  - Add tasks with optimistic, most likely, and pessimistic time estimates.
  - Define task dependencies (precedence).
- **Automatic Calculations**:
  - Compute the **expected time** for each task using the PERT formula.
  - Determine the **critical path** for the project.
- **Interactive Visualization**:
  - Render PERT charts using **Mermaid.js** (graph LR syntax).
  - Highlight the critical path for quick insights.
- **User-Friendly Interface**:
  - Simple form for inputting task details.
  - Clear and intuitive chart visualization.
- **Frappe Gantt**:
  -use frappe gantt to visualize the project timeline
  	

---

## Technologies Used

- **Backend**: ASP.NET Core 8
- **Frontend**: HTML, CSS, JavaScript
- **Charting**: [Mermaid.js](https://mermaid-js.github.io/mermaid/) (for rendering PERT charts)
- **Dependency Management**: NuGet (for .NET packages)

---

## Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- A code editor (e.g., Visual Studio, Visual Studio Code)

### Installation
1. **Clone the Repository**:
   ```bash
   git clone https://github.com/gamalmouhssine/Pert-diagram-maker.git
   cd pert-chart-generator
2. **Run the Application**:
   ```bash
   dotnet run


---


## Usage
1. **Add Tasks**:
   - Click the **Add Activity** button to create a new task.
   - Enter the task name, optimistic time, most likely time, and pessimistic time.
2. **Generate the PERT Chart:**:
   - Click the **Calculate PERT** button to render the PERT chart.
   - The chart will display the tasks, expected times, and critical path, and Gantt chart.
3. **Review the Results:**:
   - The critical path will be highlighted in the chart.
   - Verify the calculations using the PERT formula: `Expected Time (TE) = Optimistic Time (TO) + 4 x Most Likely Time (TM) + Pessimistic Time (TP) / 6`.
## Double-Checking Results
- You can double-check the critical path and expected times by calculating them manually using the PERT formula.
- The critical path is the longest path through the project network diagram and determines the minimum project duration.

---


## Contributing
Contributions are welcome! Here are some ways you can contribute:
- **Fork the repository**.
- **Create a new branch**.
- **Commit your changes**.
- **Submit a pull request**.
- **Star the repository**.
- **Share the project** with others.

---


## License
This project is licensed under the MIT License. See the LICENSE file for details.

---


## Acknowledgments
- **Mermaid.js**: For providing a simple and powerful way to create diagrams and charts.
- **Frappe Gantt**: For offering a flexible and interactive way to visualize project timelines.
- **ASP.NET Core**: For enabling cross-platform development and high-performance web applications.
- **GitHub Badges**: For creating dynamic badges to display project information.

---


## Contact
If you have any questions or feedback, feel free to reach out:
- Email: [Gamal Mouhssine](mailto:mouhssinegamal2@gmail.com)
- LinkedIn: [Gamal Mouhssine](https://www.linkedin.com/in/mouhssine-gamal/)
- GitHub: [gamalmouhssine](https://github.com/gamalmouhssine)
