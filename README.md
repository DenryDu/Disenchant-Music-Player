# [WinUI3 CSharp] 离幻 UWP 音乐播放器
### Disenchant Music Player

##### 当前进度

- 2023/3/12-21:16: [WinUI3 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI3-CSharp) 由于uwp应用安装naudio问题颇多，所以将项目整体迁移到[WinUI3 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI3-CSharp)了，今天完成了播放组件的动态数据绑定，优化了项目文件结构，优化标题栏，优化进度条。下一步编写歌曲展开页。
	![2023/3/12-1](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-12_21-15-09.png)
- 2023/3/13-11:46: [WinUI3 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI3-CSharp) 完成音量控制
	![2023/3/12-1](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-13_11-43-31.png)	
- 2023/3/13-21:00: [WinUI3 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI3-CSharp) 使用NAudio编写Audio Player类，实现了包括进度条更新、音量更新、暂停、播放、上一曲、下一曲、Shuffle播放、列表循环播放、单曲循环播放等功能，但存在严重缺陷，就是由于NAudio中的AudioFileReader缓冲区大小的问题，导致部分音乐在拖拽进度条时发生进度无法顺利更新的问题，如
	- 在播放歌曲 梦里花 时，将进度条拉到第4秒处，但声音仍然从第0秒处开始
	- 在播放大部分歌曲时，将进度条拉满，但从AudioFileReader中拿到的CurrentTime竟然比TotalTime还要大，而且仍然有音乐从大概90%进度开始播放。
	上述问题在使用NAudio官网上的WpfDemo时也有发生，同时我也进行了细致的Debug，确信不是我编程中可能出现的参数精度、线程同步所导致的，所以使用NAudio完成音乐播放的全程控制，是具有天生缺陷的，遂放弃。
- 2023/3/14-10:50: [WinUI3 C#](https://github.com/DenryDu/Disenchant-Music-Player/tree/WinUI3-CSharp) 使用MediaPlayer编写MAudioPlayer类，重新实现了进度条更新、音量更新、暂停、播放、上一曲、下一曲、Shuffle播放、列表循环播放、单曲循环播放等功能，无昨天那些缺陷，窗口最小化后仍然能够播放，目前很满意。由于不需要使用NAudio，甚至有考虑将目前进度重新移植回UWP。
	![2023/3/14-1](https://github.com/DenryDu/Disenchant-Music-Player/blob/main/Images/Snipaste_2023-03-14_10-45-30.png)	

