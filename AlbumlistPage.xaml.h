// Copyright (c) Microsoft Corporation and Contributors.
// Licensed under the MIT License.

#pragma once

#include "AlbumlistPage.g.h"

namespace winrt::DisenchantMusicPlayer::implementation
{
    struct AlbumlistPage : AlbumlistPageT<AlbumlistPage>
    {
        AlbumlistPage();

        int32_t MyProperty();
        void MyProperty(int32_t value);

    };
}

namespace winrt::DisenchantMusicPlayer::factory_implementation
{
    struct AlbumlistPage : AlbumlistPageT<AlbumlistPage, implementation::AlbumlistPage>
    {
    };
}
