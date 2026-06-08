# iot-dotnet-2026
IoT 개발자 닷넷 리포지토리

## WPF 실습

### 키오스크앱
#### 데이터베이스 연동 및 테이블 생성 
    - cafekiosk 데이터베이스 생성
    - menu 테이블 생성
```xml
CREATE TABLE menu
(
    menu_id INT PRIMARY KEY AUTO_INCREMENT,
    menu_name VARCHAR(100) NOT NULL,
    price INT NOT NULL,
    image_path VARCHAR(255),
    category VARCHAR(20),
    is_sale CHAR(1) DEFAULT 'Y'
);
```
#### 모델 클래스 
- menuitem - dbmenu 테이블과 매핑
- order item 주문 리스트 저장


#### 이미지 구현
![alt text](KakaoTalk_20260608_152941408.png)
![alt text](KakaoTalk_20260608_155008219.png)


#### 주문 내역 표시







### Open AI 연동 앱
- 미세먼지 모니터링
- 국가교통정도
- Iot 모니터링 앱
