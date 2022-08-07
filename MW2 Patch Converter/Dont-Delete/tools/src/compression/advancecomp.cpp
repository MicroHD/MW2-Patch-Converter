#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include "../7z_advancecomp/7z.h"   // from AdvanceComp



static int     sz_passes = 5;      // shrink_extreme
static int     sz_fastbytes = 255; // shrink_extreme



extern "C" int advancecomp_rfc1950(unsigned char *in, int insz, unsigned char *out, int outsz) {
    unsigned int    out_size = outsz;
    if(!compress_rfc1950_7z(in, insz, out, out_size, sz_passes, sz_fastbytes)) return(-1);
    return(out_size);
}



extern "C" int advancecomp_deflate(unsigned char *in, int insz, unsigned char *out, int outsz) {
    unsigned int    out_size = outsz;
    if(!compress_deflate_7z(in, insz, out, out_size, sz_passes, sz_fastbytes)) return(-1);
    return(out_size);
}

