// WARNING: Please don't edit this file. It was generated by C++/WinRT v2.0.220929.3

void* winrt_make_DisenchantMusicPlayer_SonglistPage()
{
    return winrt::detach_abi(winrt::make<winrt::DisenchantMusicPlayer::factory_implementation::SonglistPage>());
}
WINRT_EXPORT namespace winrt::DisenchantMusicPlayer
{
    SonglistPage::SonglistPage() :
        SonglistPage(make<DisenchantMusicPlayer::implementation::SonglistPage>())
    {
    }
}
