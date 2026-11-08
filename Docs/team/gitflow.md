# Git workflow

> Bản nháp 08/11/2026 — nhóm review và chốt.

Nhóm 3 người, 8 tuần: dùng **GitHub Flow** (một nhánh `main` + nhánh ngắn cho từng việc), không dùng Git Flow đầy đủ (develop/release/hotfix) vì quá nặng cho quy mô này.

## Nhánh

- `main` luôn mở được trong Unity và build được APK. Không push thẳng lên `main`.
- Nhánh việc: `<loại>/<module>-<mô-tả>`, ví dụ `feat/graphing-parser`, `fix/tracking-jitter`, `docs/decisions-week2`.
- Loại: `feat`, `fix`, `refactor`, `test`, `docs`, `chore`.

## Commit

Dạng Conventional Commits, tiếng Anh: `feat(graphing): add implicit multiplication to parser`.

## Pull Request

1. Mỗi PR gắn với một Issue trên GitHub Projects (`Closes #12`).
2. Cần 1 người review duyệt (CODEOWNERS tự gán theo module).
3. Squash merge, xoá nhánh sau khi merge.
4. PR có thay đổi scene/prefab: ghi rõ trong mô tả đã sửa object nào.

## Scene và file Unity

- `Main.unity`: chỉ **Duy** sửa. Người khác cần thay đổi thì làm thành prefab trong scene sandbox của mình rồi nhờ Duy đặt vào.
- Scene sandbox: mỗi người chỉ sửa scene của mình.
- Luôn commit file `.meta` cùng với file gốc.
- Merge scene/prefab bằng UnityYAMLMerge — thêm vào `.git/config` của máy mình (đổi đường dẫn nếu cài Unity chỗ khác):

```ini
[merge "unityyamlmerge"]
    name = Unity SmartMerge
    driver = ~/Unity/Hub/Editor/6000.6.4f1/Editor/Data/Tools/UnityYAMLMerge merge -p %O %B %A %A
    recursive = binary
```

## Git LFS

Ảnh, PDF, DOCX, DLL, model, video đi qua LFS (xem `.gitattributes`). Phải chạy `git lfs install` trước commit đầu tiên. Video demo và file rất lớn để trên Google Drive, trong repo chỉ để link.
