# PROGRESS REPORT

| Field | Content |
| --- | --- |
| Course | Augmented Reality – 20261 |
| Project code | 2615 |
| Project title | 3D Function Grapher on Paper |
| Design thinking page (Figma) | **[Figma link — to be added]** |
| Members | 1. Trương Văn Thái – 20231627 · 2. Âu Mạnh Hùng – 20231593 · 3. Đào Khánh Duy – 20231583 |
| Reported working period | from 02/11/2026 to 08/11/2026 (week 1 of 8) |

## 1. Summary of latest progress

Week 1 was the kick-off week, focused on analysing the topic, planning, and setting up the foundation for teamwork. The app targets Vietnamese high-school students (grades 10–12): a student scans a printed worksheet with an Android phone, sees a 2D curve or a 3D surface standing exactly on the axes printed on the page, and works through a guided Predict – Observe – Explain (POE) exercise.

We wrote an analysis and planning document. It resolves the 9 open points in the topic description with a default decision for each, lists technical and pedagogical risks with mitigations, selects the technology stack (Unity + Vuforia, NCalc, Unity Mesh API), reviews 4 similar projects and 3 research papers, names the underlying learning theories, and sets an 8-week schedule with 3 gates. The biggest risk is that graph-like worksheets have few visual features, so Vuforia may track them poorly; this is tested at Gate 1 (15/11).

We created the GitHub repository, the Unity 6000.6.4f1 project (URP, Force Text serialization), the folder structure, a 5-module architecture, team conventions (code, git, Unity workflow, team contract), a decision log, and a detailed sprint 2 plan with 22 tasks.

Cumulative progress: week 1 of 8 is complete. Analysis, planning and conventions are done. Carried over to week 2: installing Vuforia, running on an Android phone, and designing the marker. No functional code yet. Week 2 aims at Gate 1: printed worksheet v1 tracks reliably and the surface z = x² + y² appears correctly on the printed axes.

## 2. Review of technical activities

**Activity 1: Topic analysis.** Resolved 9 open points: target users are grades 10–12; equations are typed on an in-app keyboard with parameter sliders (formula OCR is an optional extra); one image target per exercise; axes printed on the worksheet, 1 unit = 1 cm by default; 6–8 POE exercises with automatic scoring; both 2D curves and 3D surfaces; Android only; single-group evaluation with pre/post test + SUS on 5–10 classmates (a study at a high school is outside the course scope). The format of guided exercises is flagged for confirmation with the lecturer.

**Activity 2: Related work review.** Reviewed 4 projects (AR 3D Graphs by Driessen, UBC Math World, Catlike Coding – Mathematical Surfaces, GeoGebra 3D AR) and 3 papers (Cheong et al. 2024; Ahmad & Junaini 2020; a systematic review in IJLTER). Key lessons: graph-like markers track poorly, and existing projects either plot a few built-in functions or are not tied to a worksheet. Learning theories: multiple representations (Ainsworth), multimedia learning and dual coding (Mayer, Paivio), POE.

**Activity 3: Technology choice and architecture.** Unity + Vuforia Engine (Basic license); NCalc for expression parsing (codewriter Expression Parser rejected: no sin/cos and it evaluates -2^2 = 4); Unity Mesh API for surfaces, LineRenderer for curves and axes. Five modules, each with its own assembly definition: `Core` (shared interfaces) ← `Tracking`, `Graphing` ← `Exercises`, `UI`. Two module interfaces are drafted (target-anchored origin, graph rendering) and will be finalised in week 2. The graph is a child of the origin (`ImageTarget → GraphRoot → Surface`), so the graphing module does not depend on Vuforia.

**Activity 4: Project setup and team conventions.** Created a Unity 6000.6.4f1 project with URP and Asset Serialization = Force Text, so scenes and prefabs are readable and diffable. Created the GitHub repository and invited Duy and Hùng; configured `.gitignore` for Unity and `.gitattributes` for Git LFS (images, PDF, DOCX, DLL) and UnityYAMLMerge; commits follow Conventional Commits. Wrote team documents: architecture overview, C# coding conventions, git workflow (GitHub Flow, Conventional Commits, scene ownership rules), Unity workflow (`.meta` files, GUIDs), team contract, and instructions for AI coding agents (`AGENTS.md`). These documents are drafts awaiting team sign-off.

**Activity 5: Planning.** 8-week schedule (02/11 – 27/12/2026) with 3 gates; three fixed roles; a decision log (first 3 decisions); a sprint 2 plan of 22 tasks, each with a "done when" criterion, plus 4 pass criteria for Gate 1.

## 3. Personal contribution

Fixed roles for the whole project: Duy – Tracking and marker; Thái – Graphing in AR + AI; Hùng – AR exercises and interaction.

| Member | Work in week 1 | Outputs | Contribution to overall progress |
| --- | --- | --- | --- |
| Member 1: Trương Văn Thái – 20231627 | Topic analysis; related work review; technology choice and architecture; GitHub repository, Unity project and folder structure; team conventions; 8-week and sprint 2 plans | Analysis & plan document; GitHub repository and Unity project; 5 team convention documents; `AGENTS.md`; decision log; sprint 2 plan | Fixed the scope, technology, architecture and team workflow for the remaining 7 weeks |
| Member 2: Âu Mạnh Hùng – 20231593 | Took part in discussing the topic analysis and plan; agreed on the role split | Feedback on the proposed decisions and role split | Confirmed the scope of the AR exercises and UI module in their charge |
| Member 3: Đào Khánh Duy – 20231583 | Took part in discussing the topic analysis and plan; agreed on the role split | Feedback on the proposed decisions and role split | Confirmed the scope of the tracking and marker module in their charge |

## 4. Developed code review

### Algorithmic development

Designed this week, not yet implemented:

- **Surface z = f(x, y):** sample an N×N grid (N = 60–100) over [xmin, xmax] × [ymin, ymax] and split each cell into 2 triangles. When a slider moves, only vertex positions are updated; no new mesh is created.
- **Undefined values:** drop triangles with a NaN/∞ vertex; clamp z to the display range; break 2D curves at discontinuities.
- **Expression parsing:** normalise textbook notation (`2x` → `2*x`, `sin x` → `sin(x)`, `x²` → `x^2`), then compile once with NCalc into a delegate.
- **Aligning AR axes with the printed axes:** use the real target width (metres) to compute the scale; place the origin O at a fixed position on the worksheet.

### Source code enhanced and/or revised

- No functional code yet.
- Unity 6000.6.4f1 (URP) project with the default sample scene.
- GitHub repository: https://github.com/navihat/3d_grapher — `.gitignore`, `.gitattributes` (Git LFS, UnityYAMLMerge); Duy and Hùng invited.

### Testing result

No functional code this week, so no functional tests. Project configuration checked: Asset Serialization = Force Text in `ProjectSettings/EditorSettings.asset`.

## 5. TODO

### a) List of remaining issues

1. Vuforia is not installed; its support for Unity 6000.6.4f1 is not yet verified.
2. No marker and no run on an Android phone yet, so the biggest risk (tracking) is still untested.
3. Team convention documents are drafts; the team contract is not signed.
4. Learning objectives and the list of 6–8 curriculum functions are not finalised.

### b) List of tasks to carry out in the next period (09/11 – 15/11, sprint 2)

**Thái – Graphing**

- [ ] S2-07: GitHub Projects board + CODEOWNERS per module
- [ ] S2-19: create `Assets/_Project/` with 5 assembly definitions; finalise the 2 interfaces in `Core`
- [ ] S2-08, S2-09: add NCalc; expression pre-processing + 30 EditMode tests
- [ ] S2-10, S2-11, S2-12: surface z = f(x, y); axes and 2D curves; height-based colouring
- [ ] S2-13: attach the surface to Duy's image target

**Duy – Tracking and marker**

- [ ] S2-01: install Vuforia, Basic license key
- [ ] S2-02, S2-03: marker worksheet v1 rated 4–5 stars; print and measure tracking
- [ ] S2-04, S2-05: `GraphRoot` aligned with the printed axes; Extended Tracking
- [ ] S2-06: Main and Sandbox scenes; APK running on 2 Android phones

**Hùng – Exercises and UI**

- [ ] S2-14, S2-15: learning objectives; finalise 6–8 functions and a POE exercise idea for each
- [ ] S2-16, S2-17: 4-screen wireframe in Figma; FigJam Ideate stage
- [ ] S2-18: Vietnamese SUS and pre/post test templates

**Whole team**

- [ ] S2-21: finalise team convention documents, sign the team contract

### c) Milestone

**Gate 1 (15/11/2026): reliable marker tracking.** Passed when all 4 hold on a real Android phone:

1. Marker v1 is rated 4–5 stars in Vuforia Target Manager.
2. The worksheet is detected at 20–40 cm and at tilts up to 60°.
3. The AR origin and axes match the printed axes (offset ≤ 2–3 mm when viewed head-on).
4. The graph stays visible when a hand covers one corner of the worksheet.

To reach Gate 1: Duy and Hùng must clone the repository and set up their environment on Monday so all three can work in parallel, Vuforia must run on Unity 6000.6.4f1, marker v1 must have its star rating by Wednesday 11/11, and Tracking and Graphing must be integrated on Saturday 14/11. If tracking is still poor on 15/11, we redesign the worksheet before continuing; if it remains poor, we consider the web fallback (MindAR.js).

**8-week roadmap**

| Week | Dates | Goal | Gate |
| --- | --- | --- | --- |
| 1 | 02–08/11 | Topic registration, analysis, planning, project setup, team conventions | |
| 2 | 09–15/11 | Worksheet v1; z = x² + y² on the printed axes, running on Android | **Gate 1:** reliable tracking |
| 3 | 16–22/11 | Parser + tests; 2D curves and 3D surfaces; axis alignment; exercise data | |
| 4 | 23–29/11 | Parameter sliders; math keyboard; multiple targets; POE flow and scoring; logging | |
| 5 | 30/11–06/12 | Integrate the 3 modules; Extended Tracking; draft exercises and pre/post questions | **Gate 2:** core feature freeze |
| 6 | 07–13/12 | 6–8 POE exercises; final printed worksheets; internal trial | **Gate 3:** ready for the study |
| 7 | 14–20/12 | Evaluation with 5–10 classmates: pre-test → learn with the app → post-test + SUS | |
| 8 | 21–27/12 | Data analysis, report, demo video, slides; submit 27/12 | |
