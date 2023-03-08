# [WinUI2-CSharp] 离幻 UWP 音乐播放器
### Disenchant Music Player

##### 当前进度

- 2023/3/6：[WinUI2 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI2-CSharp) 学习了MVVM开发模式，在此基础上构建了音乐信息相关类，完成基本信息（路径名、专辑名、歌名、艺术家）的读取整合操作，鉴于该操作基本上属于数据获取范畴，并不涉及直接为页面准备数据，所以目前放在Model层。同时，由于该软件不需要大规模频繁的插入删除修改和复杂查询，初步决定不采用数据库进行开发。
- 2023/3/7：[WinUI2 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI2-CSharp) 完成了一些音乐信息（封面，采样率，比特率，歌词，时长）的提取工作，同时解决文件访问受限情况下使用taglib读取音乐文件的问题。初步解决音乐文件夹导入问题。
- 2023/3/8：[WinUI2 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI2-CSharp) 完成了音乐库文件夹指定与取消的逻辑，以及指定文件夹后导入数据的逻辑，同时将之前使用项目中的UI进行了简单的迁移，主要完成了SongListPage和SettingsPage的View层UI设计和ViewModel层数据绑定。下一步希望分析运行时内存占用过大的原因并解决，同时解决类间权限受限情况下的参数传递。
	![2023/3/8-1](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-08_19-35-02.png)
	![2023/3/8-2](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-08_19-35-54.png)
	![2023/3/8-3](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-08_19-36-11.png)
	![2023/3/8-4](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-08_19-36-39.png)
