
## C# 获取音乐相关信息

支持大部分格式的方法: 

### 1. Microsoft Shell Controls And Automation

#### 导入方法
- 引入COM组件
- 代码中添加：using Shell32;

#### 使用方法

##### 代码示例

```
    string[] Info = new string[7];
    //Shell 对象
    ShellClass sh = new ShellClass();

    //Shell文件夹对象
    Folder dir = sh.NameSpace(System.IO.Path.GetDirectoryName(path));

    //Shell文件对象
    FolderItem item = dir.ParseName(System.IO.Path.GetFileName(path));

    //开始全面解析Shell文件对象
    Info[0] = dir.GetDetailsOf(item, 21);
    //Info[1] = dir.GetDetailsOf(item, 20);
    Info[6] = dir.GetDetailsOf(item, 14);
    Info[3] = dir.GetDetailsOf(item, 27);
    Info[3]= Info[3].Substring(Info[3].IndexOf(":") + 1);
    Info[4] = dir.GetDetailsOf(item, 1);
```

##### 参数索引

```
ID  => DETAIL-NAME
      0   => Name     //文件名
      1   => Size     //文件大小
      2   => Type     //文件格式
      3   => Date modified
      4   => Date created
      5   => Date accessed
      6   => Attributes
      7   => Offline status
      8   => Offline availability
      9   => Perceived type
      10  => Owner
      11  => Kinds
      12  => Date taken
      13  => Artists   //艺术家
      14  => Album     //专辑
      15  => Year      //出版年份
      16  => Genre
      17  => Conductors
      18  => Tags
      19  => Rating
      20  => Authors   //同艺术家
      21  => Title     //标题
      22  => Subject
      23  => Categories
      24  => Comments
      25  => Copyright
      26  => #         //编号
      27  => Length    //时长
      28  => Bit rate
      29  => Protected
      30  => Camera model
      31  => Dimensions
      32  => Camera maker
      33  => Company
      34  => File description
      35  => Program name
      36  => Duration
      37  => Is online
      38  => Is recurring
      39  => Location
      40  => Optional attendee addresses
      41  => Optional attendees
      42  => Organizer address
      43  => Organizer name
      44  => Reminder time
      45  => Required attendee addresses
      46  => Required attendees
      47  => Resources
      48  => Free/busy status
      49  => Total size
      50  => Account name
      51  => Computer
      52  => Anniversary
      53  => Assistant's name
      54  => Assistant's phone
      55  => Birthday
      56  => Business address
      57  => Business city
      58  => Business country/region
      59  => Business P.O. box
      60  => Business postal code
      61  => Business state or province
      62  => Business street
      63  => Business fax
      64  => Business home page
      65  => Business phone
      66  => Callback number
      67  => Car phone
      68  => Children
      69  => Company main phone
      70  => Department
      71  => E-mail Address
      72  => E-mail2
      73  => E-mail3
      74  => E-mail list
      75  => E-mail display name
      76  => File as
      77  => First name
      78  => Full name
      79  => Gender
      80  => Given name
      81  => Hobbies
      82  => Home address
      83  => Home city
      84  => Home country/region
      85  => Home P.O. box
      86  => Home postal code
```

#### 该方法存在的缺陷

-  部分音乐的艺术家属性为空，作者往往在唱片集艺术家属性里
- 无法访问专辑封面

### 2. Taglib-sharp
使用方法如下：

获取专辑艺术家和艺术家信息

```
    //TagLib文件对象
    TagLib.File f = TagLib.File.Create(path);

    //获取专辑艺术家列表
    if (f.Tag.AlbumArtists.Length != 0)
        Info[1] = f.Tag.AlbumArtists[0];
    else
        Info[1] = "";

    //获取艺术家列表
    if (f.Tag.Artists.Length != 0)
        Info[5] = f.Tag.Artists[0];
    else
        Info[5] = "";

    //获取专辑名称
    Info[2] = f.Tag.Album;
```

获取封面

- 获取封面数据比特流

```
    //获取专辑封面
    public static MemoryStream GetCover(string path)
    {
        TagLib.File f = TagLib.File.Create(path);
        if (f.Tag.Pictures != null && f.Tag.Pictures.Length != 0)
        {
            var bin = (byte[])(f.Tag.Pictures[0].Data.Data);
            return new MemoryStream(bin);
        }
        else
            return null;
    }
```

- 将数据流重新包装成图片
```
    var ss = GetMusicInfo.GetCover(path);
    if (ss != null)
    {
        var bitmap = new BitmapImage();
        bitmap.BeginInit();
        bitmap.StreamSource = ss;
        bitmap.CacheOption = BitmapCacheOption.OnLoad;
        bitmap.EndInit();
        bitmap.Freeze();
        image.Source = bitmap;
    }     
```

设置专辑封面

    public static void SetCover(string path)
    {
        TagLib.File file = TagLib.File.Create(path);
        TagLib.Picture pic = new TagLib.Picture();
        pic.Type = TagLib.PictureType.FrontCover;
        pic.Description = "Cover";
        pic.MimeType = System.Net.Mime.MediaTypeNames.Image.Jpeg;
        pic.Data = new TagLib.ByteVector(System.IO.File.ReadAllBytes("D://aaa//aaa.jpg"));
        file.Tag.Pictures = new TagLib.IPicture[] { pic };
        file.Save();
    }

Tag中有好多属性可以获取
不过Taglib-sharp对中文编码的支持不好，会出现乱码
建议两中方法结合使用

https://blog.csdn.net/qq_22033759/article/details/51968045

https://blog.csdn.net/u013419838/article/details/108489023?utm_medium=distribute.pc_relevant.none-task-blog-2~default~baidujs_baidulandingword~default-0-108489023-blog-51968045.pc_relevant_landingrelevant&spm=1001.2101.3001.4242.1&utm_relevant_index=3