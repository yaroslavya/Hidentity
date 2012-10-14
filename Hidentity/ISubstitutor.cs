using System;

namespace Hidentity
{
    interface ISubstitutor
    {
        int ToHiddenId(int realId);
        int ToRealId(int hiddenId);
    }
}
