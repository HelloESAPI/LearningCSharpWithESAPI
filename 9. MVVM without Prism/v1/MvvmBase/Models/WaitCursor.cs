﻿using System;
using System.Windows.Input;

namespace MvvmBase.Models
{
  public class WaitCursor : IDisposable
  {
    private Cursor _previousCursor;

    public WaitCursor()
    {
      _previousCursor = Mouse.OverrideCursor;

      Mouse.OverrideCursor = Cursors.Wait;
    }

    public void Dispose()
    {
      Mouse.OverrideCursor = _previousCursor;
    }

  }
}
