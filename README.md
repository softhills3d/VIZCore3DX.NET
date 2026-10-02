# VIZCore3DX.NET

VIZCore3DX.NET 라이브러리를 활용한 Windows Forms 예제 프로젝트 모음입니다.

## 요구 사항
- .NET Framework 4.8
- VIZCore3DX.NET 라이브러리 — **기준 버전 1.5.26.928** (각 예제 표의 `API version` 열이 그 예제를 마지막으로 빌드·확인한 라이브러리 버전입니다. 그보다 낮은 버전에서는 일부 API 가 없어 빌드되지 않을 수 있으니, 예제 버전 이상의 라이브러리를 사용하세요.)

## WinForms 예제 프로젝트
### 기본 / 뷰어
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.App** | VIZCore3DX.NET의 기본 뷰어 동작을 확인하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.Demo** | VIZCore3DX.NET의 다양한 기능을 데모 형태로 시연하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.DemoLauncher** | 예제 목록을 카테고리별로 보여주고 실행하는 런처 | DLL 미사용 |
| **VIZCore3DX.NET.ToolbarHide** | VIZCore3DX.NET 뷰어의 툴바 항목을 표시하거나 숨기는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.Frame** | Tribon / AM Frame 파일을 열거나 Frame을 생성·가져오기·내보내기하고, 축별 프레임 라인 목록과 XY / YZ / ZX 평면 표시, 프레임 라인 색상을 설정하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.Recording** | 3D 뷰 화면을 녹화하여 동영상으로 저장하는 예제 (FFMpeg 필요) | 1.1.25.609 |
| **VIZCore3DX.NET.RenderScale** | 3D 뷰의 렌더 스케일을 조정하여 렌더링 품질과 성능을 비교하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.RibbonEx** | DevExpress Ribbon 메뉴로 VIZCore3DX.NET 기능을 구성하는 예제 (DevExpress 26.1.5 필요) | 1.5.26.928 |
| **VIZCore3DX.NET.RibbonCustomization** | 리본 탭·그룹·기능을 사용자 정의 탭으로 재구성하고, 순서 변경, 빠른 실행 도구 모음 및 사용자 정의 버튼 추가를 관리하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.Print** | 3D 화면을 인쇄하고 미리보기, 머리글·바닥글·날짜·페이지 번호, 용지 방향 및 여백을 설정하는 예제 | 1.5.26.928 |

### 모델 구조 / 속성
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.Structure** | 모델을 로드하지 않은 상태에서 파일 구조와 선택한 노드의 속성 정보를 조회하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.CustomModelTree** | 모델의 노드 구조를 사용자 정의 트리 형태로 조회하고 관리하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.ModelTree** | 기본 모델 트리의 이름 필터, 정렬, 검색바, 선택 연동, 역할별 색상 및 테마를 설정하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.NodeDetail** | 선택한 노드의 색상, 투명도, 이동, 회전, UDA 및 형상 정보를 조회하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.NodeVisibleChanged** | 모델 노드의 가시성 변경을 감지하고 관련 이벤트를 처리하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.GeometryProperty** | 모델의 Surface Area, Volume, Center of Volume 및 Geometry 등 기하학 속성과 메시 집계, 동일 형상 통계, 지표 순위, 축 방향 분포를 조회하고, 기본 특성 로드 결과를 노드별로 확인하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.MeshCount** | 모델의 노드별 메시 개수와 형상 정보를 조회하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.UDA** | 선택 객체의 사용자 정의 속성 조회, 전체 속성 트리·값 분포 조회 및 속성 내보내기(CSV / JSON / XML) 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.ImportAttribute** | 외부 속성 파일을 불러와 각 모델 노드에 속성 정보를 연결하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.SplitObjects** | 모델 객체를 조건에 따라 분리하고 개별 객체로 관리하는 예제 | 1.5.26.928 |

### PMI
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.PMI** | PMI 항목, 요소, Category, Type, PMI View 및 노드별 PMI를 조회하고 표시 상태를 관리하는 예제 | 1.5.26.928 |

### 카메라 / 뷰
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.Camera.CCTV** | CCTV 카메라 위치를 설정하고 자동으로 회전시키는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.CameraControl** | 카메라 위치, 시점, 확대 및 축소를 제어하고 FOV·투영 방식을 포함해 카메라를 백업 / 복원하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.CameraDataSaver** | 3D 모델의 카메라 데이터를 저장하고 로드하여 동일한 뷰를 재현하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.MiniView** | 선택하거나 지정한 객체를 SDK 기본 미니뷰 대화상자 또는 사용자 정의 대화상자에서 조회하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.ChildView** | View에서 선택한 파트를 별도의 팝업 창(Child View)에 표시하고, 화면 분할(Sub View) 구성과 초기화 모드를 설정하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.UserView** | 사용자가 지정한 카메라 뷰를 저장하고 다시 불러오는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.FocusModes** | 선택한 노드를 X-Ray · 플라스틱 · 반투명 모드로 전환해 강조하고, 강조 색·대상 형식·X-Ray 투명도·엣지 표시를 설정하는 예제 (한 번에 한 모드만 켜짐) | 1.5.26.928 |
| **VIZCore3DX.NET.Environment** | 하늘·지면 프리셋, 바닥 격자·수면·접지 그림자, 사용자 지면 텍스처·하늘 파노라마 이미지로 환경 렌더링을 설정하는 예제 (속성 패널의 환경 탭과 같은 값) | 1.5.26.928 |
| **VIZCore3DX.NET.PreSelect** | 마우스 오버 시 노드를 미리 강조하는 사전 선택의 외곽선 색·지연 시간·이름 표시를 설정하고, 강조·해제·그룹 변경 이벤트와 잠금·선택 전환을 다루는 예제 | 1.5.26.928 |

### 검색 / 선택
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.Search** | 키워드·정규식으로 노드를 검색하고 검색 조건을 Search Set으로 저장·실행하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.ScreenSelection** | 화면 좌표·영역으로 선택 가능한 객체와 노드를 조회하고 선택 순서를 묶음 단위로 확인하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.SearchSpace** | 지정한 공간 범위에 포함된 모델 객체를 검색하고 조회하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.SelectByBox_IncludeAssembly** | 박스 선택으로 Part를 선택하고 상위 Assembly까지 포함하여 선택하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.SelectParentAssembly** | 3D 형상을 선택하여 해당 객체의 상위 Assembly 노드를 조회하고 선택하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.BoxSpaceObjects** | 3D 공간을 특정 구역으로 구분하고 구역에 포함된 객체를 조회하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.SelectionBox** | Selection Box를 생성, 삭제, 이동, 크기 변경, 분할, 병합, 그룹화, 집중 모드 및 JSON 저장·복원하고 내부 객체를 조회하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.LockedSelect** | 잠긴 객체의 선택 가능 여부와 표시 상태를 확인하고, 뷰 / 모델 트리 변경과 목록을 동기화하여 관리하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.NodeLock** | 노드 잠금 기능을 켜고 모델 Node의 잠금 상태를 설정, 해제하고 잠금 여부를 확인하는 예제 (끄면 모든 잠금 해제) | 1.5.26.928 |
| **VIZCore3DX.NET.SearchSet** | 이름 검색(빠른 검색·정규식)과 조건을 저장한 검색 세트를 실행, 저장, 내보내기하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.PickAndScreen** | 화면 지점 아래의 개체 조회(순환 선택), 광선 충돌 조회, 화면 영역으로 노드를 조회하는 예제 | 1.5.26.928 |

### 공간 / 생성
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.Zone** | 다면체 공간(Zone)을 모델 분할·선택 노드·선택 상자로 생성하고, 합집합·차집합, 색·표시, 겹침 검사, 공간 안 개체 선택·단독 표시, JSON 저장·불러오기를 하는 예제 (뷰 클릭 선택 동기·경계면 끌기 포함) | 1.5.26.928 |

### 그룹 / 색상
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.Group** | 선택한 객체를 그룹으로 생성하고 조회 및 관리하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.Painting** | 선택한 모델 노드의 색상을 변경하고 적용 결과를 확인하는 예제 | 1.5.26.928 |

### 효과 / 메시지
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.Effect** | 모델에 Effect를 생성하고 조회, 표시, 숨김 및 삭제 등 효과 상태를 관리하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.MessageDashboard** | 3D 뷰에 Message Dashboard를 생성하고 표시, 숨김, 삭제 및 속성을 관리하는 예제 | 1.5.26.928 |

### 노트 / 리뷰
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.Note** | 2D, 3D 및 표면 노트를 생성하고 관리하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.Note.V2** | 3D 공간에 다양한 유형의 노트를 추가하고 대상점 이동, CSV·JSON 저장 등 상태를 관리하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.NoteTransform** | 노트의 위치, 회전 및 크기 변환을 수행하고 결과를 확인하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.MeetingNotes** | 3D 모델에 회의용 노트와 주석을 추가하고 관리하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.DecalAnnotation** | 모델 표면에 Text / Image / Arrow Decal을 추가하고 위치, 방향, 화살표 스타일과 Decal별 표시 여부를 조정하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.Snapshot** | 스냅샷을 생성, 복원하고 JSON 파일로 내보내기/가져오기하는 예제 | 1.5.26.928 |

### 측정 / 단면
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.MeasureFrame** | 프레임 좌표계를 불러와 입력 위치에서 가장 가까운 프레임 라인까지의 X / Y / Z 거리 측정을 자동으로 생성하고, 측정 목록을 내보내는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.SectionAutoClip** | 선택한 객체의 경계 영역을 기준으로 단면을 자동 생성하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.SectionBoxControl** | 섹션 박스를 추가, 표시, 숨기기, 크기 조정, 위치 이동하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.SectionBoxSize** | 섹션 박스의 크기와 위치를 세밀하게 조정하고, 프레임 좌표(FR..)를 선택해 단면을 이동하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.SectionMoveByOsnap** | Osnap으로 선택한 위치를 기준으로 단면의 위치를 이동하는 예제 | 1.5.26.928 |

### 간섭 검사 / 충돌
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.ClashTest** | 3D 모델의 간섭(Clash) 검사를 수행하고 결과(노드 ID 포함)를 확인하며 CSV / HTML 리포트로 내보내는 예제 (primitiveCrane.vizx를 열면 [시나리오 불러오기] 버튼이 활성화되어 바로 테스트 가능) | 1.5.26.928 |
| **VIZCore3DX.NET.ClashTest_MoveTest** | 3D 모델의 이동 간섭 검사(Clash Move Test)를 수행하고 결과를 확인하는 예제 (primitiveCrane.vizx를 열면 [시나리오] 버튼이 활성화되어 이동 간섭 시나리오 3종으로 바로 테스트 가능) | 1.5.26.928 |

### 모델 비교 / 분석
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.ModelComparison** | 두 개의 3D 모델을 열어 구조, 위치, 형상 및 차이점을 비교하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.Observer** | 옵저버(관측 지점)를 배치하고 시야 분석으로 보이는 객체와 가려진 객체, 커버리지를 확인하는 예제 | 1.5.26.928 |

### 시야 / 분석
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.SightAnalysis** | 지정한 위치와 시야 옵션으로 시야를 분석하고 보이는 개체·사각 개체·히트 지점을 확인하는 예제 (합집합·취소 포함) | 1.5.26.928 |
| **VIZCore3DX.NET.Observer** | 옵저버를 추가·목록 관리·카메라 이동하고 선택한 옵저버로 시야를 분석하며 JSON 으로 저장·불러오는 예제 | 1.5.26.928 |

### 애니메이션 / 시뮬레이션
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.Animation** | Animation API를 사용하여 크레인으로 탱크를 이동시키는 예제 (크레인 모델 파일 포함, PNG 프레임 시퀀스 / MP4 동영상 내보내기) | 1.5.26.928 |
| **VIZCore3DX.NET.Explode** | 모델의 어셈블리와 부품을 FLAT / HIERARCHICAL / 전체 계층 그룹으로 나누어 단계적으로 분해하여 표시하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.GroupExplode** | 그룹 단위로 모델을 분해하고 Explode 상태를 제어하는 예제 | 1.5.26.928 |

### 변환 / 회전 / 이동
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.CustomAxisRotation** | Osnap 또는 직접 입력(X, Y, Z)으로 회전축을 지정하고, 시작~끝 각도만큼 모델을 회전시키는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.RotateModel** | 변환 행렬을 이용하여 모델의 위치와 회전을 변경하는 예제 | 1.5.26.928 |

### 형상 / 생성
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.ShapeControl** | Point, Line, Polyline, Circle, Mesh 등 다양한 Shape를 생성하고 카테고리, 표시, 선택, 이동 및 회전 상태와 히트맵 형상을 관리하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.CatenaryShape** | 두 지점과 조건을 기준으로 Catenary 형상을 생성하고 확인하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.Primitive** | Box, Cone, Cylinder, Hemisphere, Spheroid, Mesh, Torus 등 Primitive 형상과 메시 파일(STL / OBJ / PLY)을 추가하고 Osnap으로 생성 위치를 지정하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.MultiPrimitive** | 여러 Primitive를 한 번에 생성하고 기준 위치, 개수 및 Interval을 설정하여 배치하는 예제 | 1.5.26.928 |

### 투영 / 2D
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.Projection2D** | 3D 모델의 외곽 형상을 2D로 투영하고 결과를 확인하는 예제 | 1.1.25.609 |

### 이미지 / 썸네일
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.Capture3D** | 3D 모델과 미니뷰를 함께 이미지로 캡처하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.CaptureImage** | 3D 뷰 화면을 현재 / 8방향 자동 / 렌더 버퍼(오버레이 포함 선택)로 캡처하고 선택 삭제·저장하는 예제 (모델을 닫으면 목록 초기화) | 1.5.26.928 |
| **VIZCore3DX.NET.GenerateThumbnail** | 여러 모델 파일의 썸네일을 생성하고 목록에서 확인하는 예제 | 1.5.26.928 |

### 내보내기 / 변환
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.ExportNode** | 전체 모델 또는 선택 노드를 VIZX로 내보내고(노드별 개별 파일 저장 포함), 옵션을 지정해 OBJ로 내보내는 예제 (OBJ는 Model.EnableBody 필요) | 1.5.26.928 |
| **VIZCore3DX.NET.ExportSTL** | 모델을 STL(ASCII / Binary) 파일로 내보내는 예제 (Model.EnableBody 필요) | 1.5.26.928 |
| **VIZCore3DX.NET.ExportNodeStatus** | 노드 표시 상태와 리뷰 객체(노트, 측정, 단면, 스냅샷, 데칼)를 파일로 내보내고 가져와 비교·적용하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.VIZXtoVIZ** | 조회 중인 모델을 범위(전체·보이는 개체·화면에 그려진 개체·선택 개체)별로 VIZ 파일로 내보내고, VIZX 파일을 열지 않고 VIZ 파일로 변환하는 예제 | 1.5.26.928 |

### 프레임
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.FrameEditor** | Frame을 생성(모델 BoundBox 기준 균등 간격 라인)·가져오기·내보내기하고, 공간·여백·평면 색상, 축 옵션(문자·선 색상), 축별 프레임 라인(자동 등분·추가·삭제)을 편집하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.FramePrefix** | 프레임 좌표를 기준으로 객체에 접두어 정보를 설정하는 예제 | 1.5.26.928 |

### 그리드 / 좌표
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.GridThreeD** | 모델을 그리드 단위로 분할하고 내보내기, 상세 보기 및 분해 표시를 수행하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.GridThreeD.V2** | 특정 노드를 축 기준으로 회전하고 그리드 기반 공간을 분석하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.MarineAxis** | 조선 좌표계(Marine Axis)의 표시 여부와 방향을 설정하고 확인하는 예제 | 1.5.26.928 |

### 객체 스냅
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.Osnap** | 모델의 면, 점, 선 및 원 형상을 스냅 방식으로 선택하고 위치와 형상 정보를 확인하는 예제 | 1.5.26.928 |
| **VIZCore3DX.NET.Osnap2DPoint** | 상단 고정 뷰에서 Osnap으로 선택한 점의 XY 좌표를 노트로 표시하는 예제 | 1.5.26.928 |

### 입력 / 조작
| 프로젝트 | 설명 | API version |
|---|---|---|
| **VIZCore3DX.NET.Input** | InputManager를 사용하여 조작 프리셋, 감도, 이동 속도, 입력 판정 및 사용자 설정을 비교하고 적용하는 예제 | 1.5.26.928 |
