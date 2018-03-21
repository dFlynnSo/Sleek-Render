﻿using System.Text;

namespace SleekRender
{
    public static class SleekRenderCostCalculator
    {
        private static StringBuilder _sb = new StringBuilder();

        public static string GetTotalCostStringFor(SleekRenderSettings settings)
        {
            _sb.Remove(0, _sb.Length);
            _sb.Append("This info is VERY approximate and depends on target GPU architecture. Treat it as general performance overhead.\n\n");

            _sb.Append("Worst case (HiRez Low End GPU 2011-ish OpenGL ES 2.0 devices):\n\n");
            _sb.Append("\tBase overhead:\t6 ms\n");

            float totalCost = 6f;
            if (settings.bloomEnabled)
            {
                _sb.Append("\tBloom:\t\t3 ms\n");
                totalCost += 3f;
            }
            if (settings.colorizeEnabled)
            {
                _sb.Append("\tColorize:\t\t2 ms\n");
                totalCost += 2f;
            }
            if (settings.vignetteEnabled)
            {
                _sb.Append("\tVignette:\t\t0.5 ms\n");
                totalCost += 0.5f;
            }

            _sb.Append("\tTotal:\t\t"+ totalCost.ToString("F2") +" ms\n\n");

            _sb.Append("General case (Arm Mali400 GPU with 480x864 screen resolution - Galaxy S2-ish):\n\n");

            _sb.Append("\tBase overhead:\t2 ms\n");
            totalCost = 2f;
            if (settings.bloomEnabled)
            {
                _sb.Append("\tBloom:\t\t0.8 ms\n");
                totalCost += 0.8f;
            }
            if (settings.colorizeEnabled)
            {
                _sb.Append("\tColorize:\t\t0.2 ms\n");
                totalCost += 0.2f;
            }
            if (settings.vignetteEnabled)
            {
                _sb.Append("\tVignette:\t\t0.2 ms\n");
                totalCost += 0.2f;
            }
            _sb.Append("\tTotal:\t\t" + totalCost.ToString("F2") + " ms\n");

            return _sb.ToString();
        }
    }
}