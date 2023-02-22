// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

#pragma once

#include "PlaylistsPage.g.h"

namespace winrt::DisenchantMusicPlayer::implementation
{
    struct PlaylistsPage : PlaylistsPageT<PlaylistsPage>
    {
        PlaylistsPage();

        int32_t MyProperty();
        void MyProperty(int32_t value);

    };
}

namespace winrt::DisenchantMusicPlayer::factory_implementation
{
    struct PlaylistsPage : PlaylistsPageT<PlaylistsPage, implementation::PlaylistsPage>
    {
    };
}
