﻿SELECT Sender,Teacher.Name AS Sender,Receiver,Timestamp From Notification,Teacher WHERE Teacher.TID = Notification.Sender AND (Receiver = 0 OR Receiver = 1);