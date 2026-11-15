# PROGRESS REPORT

| Field | Content |
| --- | --- |
| Course | Augmented Reality – 20261 |
| Project code | 2615 |
| Project title | 3D Function Grapher on Paper |
| Design thinking page (Figma) | https://www.figma.com/board/eeyqr3DnJk9avPdyrD8QcS/Untitled?node-id=0-1&p=f&t=R2Ikjy8rmYRArX16-0 |
| Members | 1. Trương Văn Thái – 20231627 · 2. Âu Mạnh Hùng – 20231593 · 3. Đào Khánh Duy – 20231583 |
| Reported working period | from 09/11/2026 to 15/11/2026 (week 2 of 8) |

## 1. Summary of latest progress

Week 2 was spent on the lesson design. At the end of week 1 the team could not yet answer the question "what is the learning objective of the AR activity?", and that answer decides which exercises, interactions and graphs are worth building. The team held two meetings (08/11 and 10/11) to settle it.

The outcome is a proposal to narrow the project to one lesson: the volume of a solid of revolution (Grade 12 Mathematics, "Kết nối tri thức" textbook, volume 2, Lesson 13 – Geometric applications of the integral). The worksheet marker anchors the printed axes; the app draws y = f(x) on [a, b], shades the region between the curve and the x-axis, then raises the solid of revolution about the x-axis above the page. The student sets up V = π∫f(x)²dx on their own; AR is used to check their mental picture, not to give the answer. The proposal keeps the Predict – Observe – Explain (POE) cycle and is waiting for the lecturer's confirmation of scope.

The team also defined four learning objectives, the flow of one exercise, the MVP scope, and the main interaction (stacking n thin discs and increasing n with a slider until the stack matches the solid).

Cumulative progress: end of week 2 of 8. The analysis, plan, team conventions and lesson direction are in place. Week 3 implements the first prototype for this direction and takes Gate 1 (marker tracking) on 22/11.

## 2. Review of technical activities

**Activity 1: Meeting on exercise and interaction design (08/11).** Three ideas were put forward: each marker is one concrete exercise with sub-questions a, b, c; tapping the figure opens a list of things to draw, and tapping an edge shows its length; typing an equation plots its graph. The team could not decide between them because the learning objective of the AR activity was not defined: the tapping idea belongs to geometry, while the topic is about function graphs, and "fixed exercise per marker" and "free equation input" are two different modes of use. The team agreed to write the learning objective first.

**Activity 2: Choosing the lesson direction (10/11).** The meeting first considered solid geometry in Oxyz (planes, equations of planes). It was rejected: every exercise would need its own hand-built model, the graphing module would be almost unused, and the result would drift away from the topic title. The team then chose the volume of a solid of revolution, which keeps function graphing at the centre, has a real 3D object that is hard to imagine from a 2D page, and maps directly to one textbook lesson.

**Activity 3: Lesson design for the new direction.**

- Learning objectives: identify the region being rotated; recognise the resulting solid; set up the correct volume integral; explain that f(x) is the radius of the cross-section and why it is squared.
- Flow of one exercise: scan the worksheet → the app draws the graph and shades the region → the student predicts the solid → the app shows the solid → the student sets up the integral and submits the result → the app grades it and points to the wrong step (missing square, missing π, wrong bounds). The answer is never shown before the student submits.
- MVP: one marker; f(x) ≥ 0 on [a, b]; rotation about the x-axis only; 3–4 exercises from recognising the region to finding an error; a log of the number of attempts under an anonymous code.
- Outside the MVP: OCR, the region between two curves, other axes of rotation, surfaces z = f(x, y).

**Activity 4: Refinements after the meeting.** The main interaction is stacking n thin discs and raising n with a slider until the stack matches the solid, to answer "why is the integral a volume?"; the cross-section at x is secondary. Examples must not all be linear functions (those give cones, solvable with ⅓πr²h); √x and sin x on [0, π] are added, possibly with real objects such as a vase or a cup. The MVP lets students pick a function from a list and edit its coefficients; free input comes after Gate 2. Since the evaluators are classmates who already know integration, the pre/post test needs questions hard enough to avoid a ceiling effect. The team will prepare an answer to "how is this different from GeoGebra 3D?".

**Activity 5: Updating the plan (done on 16/11).** The analysis and plan document, the sprint roadmap and the project overview were revised for the new direction, and the sprint 3 plan was written. The final submission deadline in the plan was changed to 13:30 on Wednesday 23/12/2026.

## 3. Personal contribution

Fixed roles for the whole project: Duy – Tracking and marker; Thái – Graphing in AR + AI; Hùng – AR exercises and interaction.

| Member | Work in week 2 | Outputs | Contribution to overall progress |
| --- | --- | --- | --- |
| Member 1: Trương Văn Thái – 20231627 | Took part in both meetings; wrote the meeting minutes and the decision log; revised the plan, roadmap and sprint 3 plan for the new direction | Minutes of 08/11 and 10/11; updated decision log; revised analysis & plan document; sprint 3 plan | Recorded the lesson direction and turned it into a concrete plan for the graphing, tracking and exercise modules |
| Member 2: Âu Mạnh Hùng – 20231593 | Took part in the meetings on exercise design and lesson direction | Input on exercise ideas, learning objectives and the exercise flow | Shaped the scope of the AR exercises and UI module in their charge |
| Member 3: Đào Khánh Duy – 20231583 | Took part in the meetings on exercise design and lesson direction | Input on exercise ideas and on what the marker has to anchor (printed axes) | Shaped the scope of the tracking and marker module in their charge |

## 4. Developed code review

### Algorithmic development

Designed this week, not yet implemented:

- **Solid of revolution:** sample x on [a, b]; at each sample build a ring of vertices of radius f(x) around the x-axis; join neighbouring rings with triangles. Triangles with a NaN/∞ vertex are dropped. Moving a slider updates vertex positions only, without creating a new mesh.
- **Stack of n discs:** split [a, b] into n equal parts; each part is a cylinder of radius f(xᵢ) and thickness (b − a)/n. The app shows the sum of the disc volumes next to the exact value so the student sees it converge as n grows.
- **Shaded region:** a flat mesh between the sampled curve and the x-axis, lying on the printed axes.
- **Rule-based grading:** compare the submitted value with the correct volume and with the values produced by typical mistakes: π∫f(x)dx (missing square), ∫f(x)²dx (missing π), and the integral over wrong bounds. A match with one of these tells the student which step went wrong.
- **Expression reading (unchanged from week 1):** preprocess textbook notation (`2x` → `2*x`, `sin x` → `sin(x)`, `x²` → `x^2`), then compile once with NCalc.

### Source code enhanced and/or revised

- No functional code yet.
- Repository: https://github.com/navihat/3d_grapher — documentation changes this week: two meeting minutes, decision log, revised plan and sprint files.

### Testing result

No code yet, so no functional testing this week.

## 5. TODO

### a) List of remaining issues

1. The lesson direction (solid of revolution) is not yet confirmed by the lecturer.
2. Vuforia is not installed; compatibility with Unity 6000.6.4f1 is not checked.
3. No marker yet and the app has not run on an Android phone, so the biggest risk (tracking) is still untested.
4. The sprint 2 implementation tasks moved to sprint 3, which makes week 3 a heavy week.
5. The team convention documents are still drafts; the team contract is not signed.

### b) List of tasks to carry out in the next period (16/11 – 22/11, sprint 3)

**Thái – Graphing**

- [ ] S3-02: ask the lecturer to confirm the lesson direction
- [ ] S2-19: create `Assets/_Project/` with 5 assembly definitions; fix the 2 interfaces in `Core`
- [ ] S2-08, S2-09: add NCalc; expression preprocessing + 30 EditMode tests
- [ ] S2-11, S2-10: curve y = f(x) with shaded region; solid of revolution about the x-axis
- [ ] S2-13: attach the graph and the solid to Duy's target, run on Android
- [ ] S2-25: learning-theory justification for the new direction
- [ ] S3-05, S3-06: 50 parser tests with domain check; discontinuities and in-place mesh updates

**Duy – Tracking and marker**

- [ ] S2-01: install Vuforia, Basic licence key
- [ ] S2-02, S2-03: worksheet marker v1 with printed axes, 4–5 stars; print and measure tracking
- [ ] S2-04, S2-05: `GraphRoot` aligned with the printed axes; Extended Tracking
- [ ] S2-06: Main and Sandbox scenes; APK running on 2 Android phones
- [ ] S3-04: measure and correct the offset between AR axes and printed axes

**Hùng – Exercises and UI**

- [ ] S2-14, S2-15: learning objectives; function set with bounds and 3–4 POE exercises
- [ ] S2-16, S2-17: 4-screen wireframe in Figma; Ideate part of the FigJam board
- [ ] S3-01: exercise data structure (ScriptableObject)
- [ ] S3-07: load a sample exercise from data and plot it through the `Core` interface
- [ ] S2-18: Vietnamese SUS and pre/post test templates

**Research**

- [ ] S2-23: re-read 3 papers, one each, at most one page of summary per paper
- [ ] S2-24: re-analyse 4 similar projects, including the comparison with GeoGebra 3D

**Whole team**

- [ ] S2-21: finalise the team convention documents, sign the team contract

### c) Milestone

**Gate 1 (22/11/2026, moved from 15/11): stable marker tracking.** Passed when all four hold on a real Android phone:

1. Marker v1 scores 4–5 stars in Vuforia Target Manager.
2. The worksheet is recognised at 20–40 cm and tilted up to 60°.
3. The origin O and the axes of the AR graph coincide with the printed axes (within 2–3 mm when viewed from above).
4. With a hand covering one corner of the worksheet, the graph stays visible.

If tracking is still poor on 22/11, the team redesigns the worksheet at the start of sprint 4; if it remains poor, the web fallback (MindAR.js) is considered.

**8-week roadmap**

| Week | Dates | Goal | Gate |
| --- | --- | --- | --- |
| 1 | 02–08/11 | Topic registration, analysis, plan, project setup, team conventions | |
| 2 | 09–15/11 | Lesson direction: volume of a solid of revolution; learning objectives, exercise flow, MVP scope | |
| 3 | 16–22/11 | Worksheet v1; parser + tests; curve y = f(x), shaded region, solid of revolution on the printed axes, running on Android; exercise data | **Gate 1:** stable marker tracking |
| 4 | 23–29/11 | Stack of n discs with slider; function list with editable coefficients; math keypad for answers; POE flow and grading; logging | |
| 5 | 30/11–06/12 | Integrate 3 modules; Extended Tracking; draft exercise content and pre/post questions | **Gate 2:** core features frozen |
| 6 | 07–13/12 | 3–4 POE exercises complete; print final worksheets; internal trial | **Gate 3:** ready for evaluation |
| 7 | 14–20/12 | Evaluation with 5–10 classmates: pre-test → learning with the app → post-test + SUS | |
| 8 | 21–23/12 | Data analysis, report, demo video, slides; submit before 13:30 on 23/12 | |
