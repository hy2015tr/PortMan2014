# PortMan2014


Analysis and Development Document

| **Written by** | Hasan YILDIRIM ( SAP/NET Consultant) \@ **PIA** |
|----------------|-------------------------------------------------|
| **Email**      | HasanYildirim\@hotmail.com                      |
| **Place**      | TeknoPark / Kurtkoy / İSTANBUL                  |
| **Date**       | 27.March.2015                                   |
| **Version**    | v1.0                                            |

**[1] Purpose of This Software :**

Managing different vendor equipment, checking their port status and
administration of all devices have been always a challenge in a wide range
networks. PortMan2014 was developed for this purpose. It is tailor made, custom
tool for the infrastructure people. The final version of PortMan2014 is
supporting **CISCO / HUAWEI / ALCATEL** modules. It also includes important
notification reports for Alcatel Infrastructure.

![cid:image002.jpg\@01D01ACE.24C26850](media/c85d093244e480792715fc13b1277cb0.jpg)

![cid:image003.png\@01D01ACC.DFED3620](media/db3bbcc38691380f32ce1f35ec369bb3.png)

![cid:image005.jpg\@01D01ACE.24C26850](media/dd0fb85a94ba0280fc40a08fece0e8ad.jpg)

![cid:image007.jpg\@01D01ACE.24C26850](media/aa935a0f46ee8adabe9683ee28cada7d.jpg)

![cid:image013.png\@01D01ACE.18CAE680](media/9d17ef11b59e323fe618a94cf7a74ac2.png)

![cid:image009.png\@01D01ACE.24C26850](media/46a3931c90de55ee001fab5857d9a049.png)


## Function List for Vendors


**HUAWEI – List :**

1) system-view

2) user-interface current

3) screen-length 0

4) screen-width 200

5) display inter description

**HUAWEI – Reserve :**

1) system-view

2) interface GigabitEthernet {0}

3) description {0}

**HUAWEI – Rollback :**

1) system-view

2) interface GigabitEthernet {0}

3) undo description {0}

**CISCO – List :**

1) terminal width 0

2) terminal length 0

3) show interfaces description

**CISCO – Reserve :**

1) config terminal

2) interface GigabitEthernet {0}

3) description {0}

**CISCO – Rollback :**

1) config terminal

2) interface GigabitEthernet {0}

3) no description {0}

**ALCATEL – List :**

1) environment no more

2) show port description  (it gives only port number and description)

3) show port (it gives port number and status, sfp information)

**ALCATEL – Reserve :**

1) configure port {0} description

**ALCATEL – Rollback :**

1) configure port {0} no description

---------------------------------------------------------------