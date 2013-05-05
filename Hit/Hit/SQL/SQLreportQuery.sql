SELECT RequestThemes.RequestTheme, RequestTypes.RequestType, Requests.RequestDate
FROM Requests 
INNER JOIN RequestThemes ON Requests.RequestThemeId = RequestThemes.RequestThemeId 
INNER JOIN RequestTypes ON Requests.RequestTypeId = RequestTypes.RequestTypeId